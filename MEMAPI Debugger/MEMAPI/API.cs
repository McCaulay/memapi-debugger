using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger.MEMAPI
{
    public static class API
    {
        private static TcpClient client;
        public static System.Threading.Thread interruptThread;

        public static string IP { get; set; }
        public static Process ActiveProcess { get; set; }
        public static int ProcessId => ActiveProcess.Id;

        // Enums
        private enum CallType
        {
            NO_TYPE = 0,
            POKE = 1,
            PEEK = 2,
            GET_HWID = 3,
            GET_PROCESSES = 4,
            GET_MODULES = 5,
            GET_REGIONS = 6,
            GET_FIRMWARE = 7,
            GET_PSID = 8,
            GET_IDPS = 9,
            SEARCH_START = 10,
            SEARCH_RESCAN = 11,
            SEARCH_GET_RESULTS = 12,
            SEARCH_COUNT_RESULTS = 13,
            SEARCH_END = 14,
            ATTACH = 15,
            DETACH = 16,
            NOTIFY = 17,
            DEBUG_CONTINUE = 18,
            DEBUG_STOP = 19,
            DEBUG_KILL = 20,
            DEBUG_STEP = 21,
            DEBUG_GET_REGISTERS = 22,
            DEBUG_SET_REGISTERS = 23,
            DEBUG_GET_FLOAT_REGISTERS = 24,
            DEBUG_SET_FLOAT_REGISTERS = 25,
            DEBUG_GET_DEBUG_REGISTERS = 26,
            DEBUG_SET_DEBUG_REGISTERS = 27,
            DEBUG_ADD_BREAKPOINT = 28,
            DEBUG_REMOVE_BREAKPOINT = 29,
            DEBUG_ADD_WATCHPOINT = 30,
            DEBUG_REMOVE_WATCHPOINT = 31,
            GET_PROCESS_THREADS = 32,
            DEBUG_STOP_THREAD = 33,
            DEBUG_RESUME_THREAD = 34,
            DEBUG_CHECK_INTERRUPT = 35
        };
        public enum ErrorCode
        {
            NO_ERROR = 0,
            INVALID_PARAMETER = 1,
            INVALID_ADDRESS = 2,
            CTL_ERROR = 3,
            SEARCH_NOT_STARTED = 4,
            FAILED_ATTACH = 5,
            NOT_CONNECTED = 6,
            NO_DATA = 7,
            INVALID_RESPONSE = 8,
            INVALID_CALL_TYPE = 9,
            REQUEST_FAILED = 10,
            INVALID_REGISTER_INDEX = 11,
            NO_INTERRUPT = 12
        };
        private enum Interrupt
        {
            UNKNOWN = 0,
            SIGTRAP = 5,
            SIGKILL = 9,
            SIGSTOP = 17,
            SIGCONT = 19
        };

        // Structs
        private struct RequestPacket
        {
            public CallType type;
            public byte[] data;
        };
        private struct ResponsePacket
        {
            public ErrorCode error;
            public byte[] data;
        };

        // Events
        public static event EventHandler ConnectedEvent;
        public static event EventHandler DisconnectEvent;
        public static event EventHandler AttachedEvent;
        public static event EventHandler DetachedEvent;
        public static event EventHandler GoEvent;
        public static event EventHandler StoppedEvent;
        public static event EventHandler SteppedEvent;
        public static event EventHandler KilledEvent;
        public static event EventHandler TrappedEvent;

        static API()
        {
            client = new TcpClient();
            interruptThread = new System.Threading.Thread(checkInterrupts);
            interruptThread.IsBackground = true;
        }

        #region Core
        public static bool connect()
        {
            if (isConnected())
                disconnect();
            client = new TcpClient();
            try
            {
                if (!client.ConnectAsync(IP, 9023).Wait(350))
                    return false;
                onConnected(EventArgs.Empty);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void disconnect()
        {
            if (isConnected())
            {
                detach();
                client.Close();
                client = null;
            }
            onDisconnected(EventArgs.Empty);
        }
        public static bool attach(Process process = null)
        {
            // If a process is passed, set it as the active process.
            if (process != null)
                ActiveProcess = process;

            // Return false if there is no active process set
            if (ActiveProcess == null)
                return false;

            if (request(CallType.ATTACH, convertToBytes(ProcessId)).error != ErrorCode.NO_ERROR)
            {
                ActiveProcess = null;
                return false;
            }

            // Continue execution
            go();

            onAttached(EventArgs.Empty);
            return true;
        }
        public static void detach()
        {
            request(CallType.DETACH, convertToBytes(ProcessId));
            onDetached(EventArgs.Empty);
        }
        public static bool isConnected()
        {
            if (client == null)
                return false;
            return client.Connected;
        }
        public static bool isAttached()
        {
            return isConnected() && ActiveProcess != null;
        }
        public static bool payload(byte[] payload)
        {
            TcpClient payloadClient = new TcpClient();
            try
            {
                bool connected = payloadClient.ConnectAsync(IP, 9020).Wait(20);
                if (!connected)
                {
                    payloadClient.Close();
                    return false;
                }

                NetworkStream cStream = payloadClient.GetStream();
                cStream.Write(payload, 0, payload.Length);
                cStream.Flush();

                payloadClient.Close();
                return true;
            }
            catch
            {
                payloadClient.Close();
                return false;
            }
        }
        private static ResponsePacket request(RequestPacket req)
        {
            ResponsePacket response;
            response.error = ErrorCode.NOT_CONNECTED;
            response.data = new byte[16384];
            try
            {
                if (isConnected())
                {
                    // Allocate write buffer
                    int writeLen = req.data != null ? req.data.Length : 0;

                    if (req.type != CallType.NO_TYPE)
                        writeLen++;

                    byte[] toWrite = new byte[writeLen];

                    // Fill buffer
                    int offset = 0;
                    if (req.type != CallType.NO_TYPE)
                    {
                        toWrite[0] = (byte)req.type;
                        offset++;
                    }

                    if (req.data != null)
                        Array.Copy(req.data, 0, toWrite, offset, req.data.Length);

                    // Send buffer
                    NetworkStream cStream = client.GetStream();
                    cStream.Write(toWrite, 0, toWrite.Length);
                    cStream.Flush();

                    if (req.type != CallType.NO_TYPE)
                    {
                        byte[] toRead = new byte[16384];
                        Task<int> task = cStream.ReadAsync(toRead, 0, 16384);

                        if (task.Wait(500))
                        {
                            int len = task.Result;
                            response.error = (ErrorCode)toRead[0];
                            if (response.error == ErrorCode.NO_ERROR && len > 1)
                            {
                                Array.Copy(toRead, 1, response.data, 0, len - 1);
                                Array.Resize<byte>(ref response.data, len - 1);
                            }
                            else
                                response.data = new byte[0];
                        }
                        else
                        {
                            response.error = ErrorCode.NO_DATA;
                            response.data = new byte[0];
                        }
                    }
                    return response;
                }
            }
            catch
            {
                response.error = ErrorCode.REQUEST_FAILED;
            }
            return response;
        }
        private static ResponsePacket request(CallType type, byte[] data = null)
        {
            RequestPacket packet;
            packet.type = type;
            packet.data = data;
            return request(packet);
        }
        #endregion

        #region Events
        private static void onConnected(EventArgs e) => ConnectedEvent?.Invoke(null, e);
        private static void onDisconnected(EventArgs e) => DisconnectEvent?.Invoke(null, e);
        private static void onAttached(EventArgs e) => AttachedEvent?.Invoke(null, e);
        private static void onDetached(EventArgs e) => DetachedEvent?.Invoke(null, e);
        private static void onGo(EventArgs e) => GoEvent?.Invoke(null, e);
        private static void onStopped(EventArgs e) => StoppedEvent?.Invoke(null, e);
        private static void onStepped(EventArgs e) => SteppedEvent?.Invoke(null, e);
        private static void onKilled(EventArgs e) => KilledEvent?.Invoke(null, e);
        private static void onTrapped(EventArgs e) => TrappedEvent?.Invoke(null, e);
        #endregion

        #region Misc
        public static List<Process> getProcesses(out ErrorCode error)
        {
            List<Process> processes = new List<Process>();
            ResponsePacket response = request(CallType.GET_PROCESSES);

            error = response.error;
            if (error == ErrorCode.NO_ERROR)
            {
                int processId = 0;
                string processName = "";

                int stage = 0;
                int offset = 0;
                while (offset < response.data.Length)
                {
                    if (stage == 0)
                    {
                        byte[] tmpArr = new byte[4];
                        Array.Copy(response.data, offset, tmpArr, 0, 4);
                        processId = BitConverter.ToInt32(tmpArr, 0);
                        offset += 4;
                        stage = 1;
                    }
                    else if (stage == 1)
                    {
                        while (response.data[offset] != 0x00)
                        {
                            processName += System.Text.Encoding.UTF8.GetString(new byte[] { response.data[offset] });
                            offset++;
                        }
                        offset++;
                        stage++;
                    }
                    else
                    {
                        processes.Add(new Process(processId, processName));
                        processId = 0;
                        processName = "";
                        stage = 0;
                    }
                }
            }
            return processes;
        }
        public static List<Thread> getProcessThreads(out ErrorCode error, int processId = -1)
        {
            if (processId == -1)
                processId = ProcessId;

            ResponsePacket response = request(CallType.GET_PROCESS_THREADS, convertToBytes(processId));
            error = response.error;

            uint[] threadIds = convertFromBytes<uint>(response.data, response.data.Length / sizeof(uint));
            List<Thread> threads = new List<Thread>();
            foreach (uint threadId in threadIds)
                threads.Add(new Thread(threadId));

            return threads;
        }
        public static ErrorCode notify(string message)
        {
            return request(CallType.NOTIFY, mergeByteArrays(
                convertToBytes(222),
                convertToBytes(message.Length),
                convertToBytes(message)
            )).error;
        }
        public static List<Module> getModules(out ErrorCode error)
        {
            List<Module> modules = new List<Module>();
            ResponsePacket response = request(CallType.GET_MODULES);

            error = response.error;
            if (error != ErrorCode.NO_ERROR)
                return modules;

            int offset = 0;
            while (offset < response.data.Length)
            {
                byte[] buffer;
                int moduleId = 0;
                string moduleName = "";
                ulong[] moduleSizes = new ulong[2];

                // Get Id
                buffer = new byte[4];
                Array.Copy(response.data, offset, buffer, 0, 4);
                moduleId = convertFromBytes<int>(buffer);
                offset += 4;

                // Get Name
                while (response.data[offset] != 0x00)
                {
                    moduleName += Encoding.UTF8.GetString(new byte[] { response.data[offset] });
                    offset++;
                }
                offset++;

                // Get Code / Data Size
                buffer = new byte[16];
                Array.Copy(response.data, offset, buffer, 0, 16);
                moduleSizes = convertFromBytes<ulong>(buffer, 2);
                offset += 16;

                modules.Add(new Module(moduleId, moduleName, moduleSizes[0], moduleSizes[1]));
            }

            return modules;
        }
        public static List<MemoryRange> getRegions(out ErrorCode error)
        {
            List<MemoryRange> ranges = new List<MemoryRange>();
            ResponsePacket response = request(CallType.GET_REGIONS, convertToBytes(ProcessId));

            error = response.error;
            if (error != ErrorCode.NO_ERROR)
                return ranges;

            int offset = 0;
            while (offset < response.data.Length)
            {
                byte[] buffer = new byte[16];
                Array.Copy(response.data, offset, buffer, 0, 16);

                ulong[] range = convertFromBytes<ulong>(buffer, 2);

                ranges.Add(new MemoryRange(range[0], range[1]));
                offset += 16;
            }

            return ranges;
        }
        public static string getFirmware()
        {
            ResponsePacket response = request(CallType.GET_FIRMWARE);

            string firmware = null;
            if (response.error == ErrorCode.NO_ERROR)
                return convertFromBytes<string>(response.data);
            return firmware;
        }
        private static void checkInterrupts()
        {
            while (true)
            {
                if (isAttached())
                {
                    ErrorCode error;
                    Interrupt? interrupt = getInterrupt(out error);
                    if (error != ErrorCode.NO_INTERRUPT && interrupt != null)
                    {
                        switch (interrupt)
                        {
                            case Interrupt.SIGSTOP:
                                onStopped(EventArgs.Empty);
                                break;
                            case Interrupt.SIGKILL:
                                break;
                            case Interrupt.SIGTRAP:
                                onTrapped(EventArgs.Empty);
                                onStopped(EventArgs.Empty);
                                break;
                            case Interrupt.SIGCONT:
                                break;
                        }
                    }
                }
                System.Threading.Thread.Sleep(500);
            }
        }
        private static Interrupt? getInterrupt(out ErrorCode error)
        {
            ResponsePacket response = request(CallType.DEBUG_CHECK_INTERRUPT, convertToBytes(ProcessId));

            error = response.error;
            if (error != ErrorCode.NO_ERROR)
                return null;

            int inter = convertFromBytes<int>(response.data);
            if (!Enum.IsDefined(typeof(Interrupt), inter))
                return Interrupt.UNKNOWN;
            return (Interrupt)inter;
        }
        #endregion

        #region Debug
        public static ErrorCode go()
        {
            ResponsePacket response = request(CallType.DEBUG_CONTINUE, convertToBytes(ProcessId));
            if (response.error == ErrorCode.NO_ERROR)
                onGo(EventArgs.Empty);
            return response.error;
        }
        public static ErrorCode stop()
        {
            ResponsePacket response = request(CallType.DEBUG_STOP, convertToBytes(ProcessId));
            // if (response.error == ErrorCode.NO_ERROR)
                // onStopped(EventArgs.Empty);
            return response.error;
        }
        public static ErrorCode step()
        {
            ResponsePacket response = request(CallType.DEBUG_STEP, convertToBytes(ProcessId));
            if (response.error == ErrorCode.NO_ERROR)
                onStepped(EventArgs.Empty);
            return response.error;
        }
        public static ErrorCode kill()
        {
            ResponsePacket response = request(CallType.DEBUG_KILL, convertToBytes(ProcessId));
            if (response.error == ErrorCode.NO_ERROR)
            {
                onKilled(EventArgs.Empty);
                detach();
            }
            return response.error;
        }
        public static Registers getRegisters(out ErrorCode error)
        {
            ResponsePacket response = request(CallType.DEBUG_GET_REGISTERS, convertToBytes(ProcessId));
            Registers regs = new Registers();
            error = response.error;
            if (response.error == ErrorCode.NO_ERROR)
            {
                int offset = 0;

                ulong[] registers = convertFromBytes<ulong>(response.data, 15); offset += (sizeof(ulong) * 15);
                regs.r15 = registers[0]; regs.r15 = registers[0]; regs.r14 = registers[1];
                regs.r13 = registers[2]; regs.r12 = registers[3]; regs.r11 = registers[4];
                regs.r10 = registers[5]; regs.r9 = registers[6]; regs.r8 = registers[7];
                regs.rdi = registers[8]; regs.rsi = registers[9]; regs.rbp = registers[10];
                regs.rbx = registers[11]; regs.rdx = registers[12]; regs.rcx = registers[13];
                regs.rax = registers[14];
                regs.trapno = convertFromBytes<uint>(response.data, offset, sizeof(uint)); offset += sizeof(uint);
                regs.fs = convertFromBytes<ushort>(response.data, offset, sizeof(ushort)); offset += sizeof(ushort);
                regs.gs = convertFromBytes<ushort>(response.data, offset, sizeof(ushort)); offset += sizeof(ushort);
                regs.err = convertFromBytes<uint>(response.data, offset, sizeof(uint)); offset += sizeof(uint);
                regs.es = convertFromBytes<ushort>(response.data, offset, sizeof(ushort)); offset += sizeof(ushort);
                regs.ds = convertFromBytes<ushort>(response.data, offset, sizeof(ushort)); offset += sizeof(ushort);
                regs.rip = convertFromBytes<ulong>(response.data, offset, sizeof(ulong)); offset += sizeof(ulong);
                regs.cs = convertFromBytes<ulong>(response.data, offset, sizeof(ulong)); offset += sizeof(ulong);
                regs.rflags = convertFromBytes<ulong>(response.data, offset, sizeof(ulong)); offset += sizeof(ulong);
                regs.rsp = convertFromBytes<ulong>(response.data, offset, sizeof(ulong)); offset += sizeof(ulong);
                regs.ss = convertFromBytes<ulong>(response.data, offset, sizeof(ulong)); offset += sizeof(ulong);
            }
            return regs;
        }
        public static ErrorCode resetHardwareBreakpoint(int index)
        {
            return request(CallType.DEBUG_REMOVE_WATCHPOINT, mergeByteArrays(
                convertToBytes(ProcessId),
                convertToBytes(index)
            )).error;
        }
        public static void resetHardwareBreakpoints(int[] indexes)
        {
            foreach (int index in indexes)
                resetHardwareBreakpoint(index);
        }
        public static ErrorCode setHardwareBreakpoint(HardwareBreakpoint breakpoint)
        {
            return request(CallType.DEBUG_ADD_WATCHPOINT, mergeByteArrays(
                convertToBytes(ProcessId),
                convertToBytes(breakpoint.Index),
                convertToBytes(breakpoint.Address),
                convertToBytes((int)breakpoint.ByteLength),
                convertToBytes((int)breakpoint.Type)
            )).error;
        }
        public static void setHardwareBreakpoints(List<HardwareBreakpoint> breakpoints)
        {
            foreach (HardwareBreakpoint breakpoint in breakpoints)
                setHardwareBreakpoint(breakpoint);
        }
        #endregion

        #region Write Data
        public static ErrorCode write<T>(ulong address, T[] elements)
        {
            byte[] buffer = convertToBytes(elements);
            return request(CallType.POKE, mergeByteArrays(
                convertToBytes(ProcessId),
                convertToBytes(address),
                convertToBytes(buffer.Length),
                buffer
            )).error;
        }
        public static ErrorCode write<T>(ulong address, T element) => write(address, new T[] { element });
        #endregion

        #region Read Data
        public static T[] read<T>(ulong address, int elements, out ErrorCode error)
        {
            T item = default(T);
            RequestPacket packet;
            ResponsePacket response;

            error = ErrorCode.NOT_CONNECTED;

            // Deal with string
            if (typeof(T) == typeof(string))
            {
                int readSize = 0x100;
                ulong offset = 0x00;
                List<string> strings = new List<string>();

                while (strings.Count < elements)
                {

                    // Read the data
                    packet.type = CallType.PEEK;
                    packet.data = mergeByteArrays(
                        convertToBytes(ProcessId),
                        convertToBytes(address + offset),
                        convertToBytes(readSize)
                    );

                    response = request(packet);
                    error = response.error;

                    strings.AddRange(convertFromBytes<string[]>(response.data));

                    offset += address;
                }

                return (T[])Convert.ChangeType(strings.GetRange(0, elements).ToArray(), typeof(T[]));
            }

            int byteCount = Marshal.SizeOf(item);
            int bytesToRead = elements * byteCount;

            packet.type = CallType.PEEK;
            packet.data = mergeByteArrays(
                convertToBytes(ProcessId),
                convertToBytes(address),
                convertToBytes(bytesToRead)
            );

            response = request(packet);
            error = response.error;
            return convertFromBytes<T>(response.data, elements);
        }
        public static T read<T>(ulong address, out ErrorCode error) => read<T>(address, 1, out error)[0];
        #endregion

        #region Search Data
        public static ErrorCode search<T>(ulong start, ulong end, T[] elements)
        {
            byte[] buffer = convertToBytes(elements);
            return request(CallType.SEARCH_START, mergeByteArrays(
                convertToBytes(ProcessId),
                convertToBytes(start),
                convertToBytes(end),
                convertToBytes(buffer.Length),
                buffer
            )).error;
        }
        public static ErrorCode search<T>(ulong start, ulong end, T element) => search(start, end, new T[] { element });
        public static ErrorCode rescan<T>(T[] elements)
        {
            byte[] buffer = convertToBytes(elements);
            return request(CallType.SEARCH_RESCAN, mergeByteArrays(
                convertToBytes(ProcessId),
                convertToBytes(buffer.Length),
                buffer
            )).error;
        }
        public static ErrorCode rescan<T>(T element) => rescan(new T[] { element });
        public static int getResultsCount()
        {
            ResponsePacket response = request(CallType.SEARCH_COUNT_RESULTS);
            if (response.error == ErrorCode.NO_ERROR)
                return convertFromBytes<int>(response.data);
            return -1;
        }
        public static ulong[] getResults()
        {
            int resultCount = getResultsCount();
            if (resultCount <= 0)
                return new ulong[0];

            ResponsePacket response = request(CallType.SEARCH_GET_RESULTS);
            if (response.error != ErrorCode.NO_ERROR && response.data.Length == (resultCount * sizeof(ulong)))
                return new ulong[0];

            return convertFromBytes<ulong>(response.data, resultCount);
        }
        public static ErrorCode endSearch() => request(CallType.SEARCH_END).error;
        #endregion

        #region Merge Byte Arrays
        public static byte[] mergeByteArrays(params byte[][] arrays)
        {
            int size = 0;
            for (int i = 0; i < arrays.Length; i++)
                size += arrays[i].Length;

            byte[] buffer = new byte[size];

            int offset = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                Buffer.BlockCopy(arrays[i], 0, buffer, offset, arrays[i].Length);
                offset += arrays[i].Length;
            }

            return buffer;
        }
        #endregion

        #region Convert To Bytes
        public static byte[] convertToBytes<T>(T[] items)
        {
            // If no items, return empty array
            if (items.Length == 0)
                return new byte[0];
        
            byte[] data;

            // Deal with string
            if (items[0].GetType() == typeof(string))
            {
                int length = 0;
                for (int i = 0; i < items.Length; i++)
                    length += items[i].ToString().Length/* + 1*/;

                data = new byte[length];
                int offset = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    Array.Copy(Encoding.UTF8.GetBytes(items[i].ToString()), 0, data, offset, items[i].ToString().Length);
                    offset += items[i].ToString().Length/* + 1*/;
                    // data[offset - 1] = 0x00;
                }
                return data;
            }

            // Deal with bytes
            if (items[0].GetType() == typeof(byte))
                return (byte[])Convert.ChangeType(items, typeof(byte[]));

            int byteCount = Marshal.SizeOf(items[0]);

            // Deal with other types
            data = new byte[items.Length * byteCount];
            for (int i = 0; i < items.Length; i++)
            {
                byte[] typeData = new byte[8];
                TypeCode code = Type.GetTypeCode(typeof(T));
                switch (code)
                {
                    case TypeCode.Int16:
                        typeData = BitConverter.GetBytes((short)Convert.ChangeType(items[i], typeof(short)));
                        break;
                    case TypeCode.UInt16:
                        typeData = BitConverter.GetBytes((ushort)Convert.ChangeType(items[i], typeof(ushort)));
                        break;
                    case TypeCode.Int32:
                        typeData = BitConverter.GetBytes((int)Convert.ChangeType(items[i], typeof(int)));
                        break;
                    case TypeCode.UInt32:
                        typeData = BitConverter.GetBytes((uint)Convert.ChangeType(items[i], typeof(uint)));
                        break;
                    case TypeCode.Int64:
                        typeData = BitConverter.GetBytes((long)Convert.ChangeType(items[i], typeof(long)));
                        break;
                    case TypeCode.UInt64:
                        typeData = BitConverter.GetBytes((ulong)Convert.ChangeType(items[i], typeof(ulong)));
                        break;
                    case TypeCode.Double:
                        typeData = BitConverter.GetBytes((double)Convert.ChangeType(items[i], typeof(double)));
                        break;
                    case TypeCode.Single:
                        typeData = BitConverter.GetBytes((float)Convert.ChangeType(items[i], typeof(float)));
                        break;
                }
                Array.Copy(typeData, 0, data, i * byteCount, byteCount);
            }
            return data;
        }
        public static byte[] convertToBytes<T>(T item) => convertToBytes(new T[] { item });
        #endregion

        #region Convert From Bytes
        public static T[] convertFromBytes<T>(byte[] data, int elements)
        {
            // If no data, return empty array
            if (data.Length == 0)
                return new T[0];

            // Deal with string
            if (typeof(T) == typeof(string))
            {
                string current = "";
                List<string> strings = new List<string>();

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == 0x00)
                    {
                        strings.Add(current);
                        current = "";
                        continue;
                    }

                    if (data[i] >= 0x20 && data[i] <= 0x7E)
                        current += System.Text.Encoding.UTF8.GetString(new byte[] { data[i] });
                }

                strings.Add(current);
                current = "";

                return (T[])Convert.ChangeType(strings.ToArray(), typeof(T[]));
            }
            
            // Deal with bytes
            if (typeof(T) == typeof(byte))
                return (T[])Convert.ChangeType(data, typeof(T[]));

            T item = default(T);

            int byteCount = Marshal.SizeOf(item);

            T[] items = new T[elements];

            for (int i = 0; i < elements; i++)
            {
                byte[] buffer = new byte[byteCount];
                Array.Copy(data, byteCount * i, buffer, 0, byteCount);

                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Int16:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToInt16(buffer, 0), typeof(T));
                        break;
                    case TypeCode.UInt16:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToUInt16(buffer, 0), typeof(T));
                        break;
                    case TypeCode.Int32:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToInt32(buffer, 0), typeof(T));
                        break;
                    case TypeCode.UInt32:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToUInt32(buffer, 0), typeof(T));
                        break;
                    case TypeCode.Int64:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToInt64(buffer, 0), typeof(T));
                        break;
                    case TypeCode.UInt64:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToUInt64(buffer, 0), typeof(T));
                        break;
                    case TypeCode.Double:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToDouble(buffer, 0), typeof(T));
                        break;
                    case TypeCode.Single:
                        items[i] = (T)Convert.ChangeType(BitConverter.ToSingle(buffer, 0), typeof(T));
                        break;
                }
            }

            return items;
        }
        public static T convertFromBytes<T>(byte[] data) => convertFromBytes<T>(data, 1)[0];
        public static T convertFromBytes<T>(byte[] data, int offset, int length) => convertFromBytes<T>(splitByteArray(data, offset, length));
        #endregion

        #region Helpers
        public static byte[] splitByteArray(byte[] data, int offset, int length)
        {
            byte[] buffer = new byte[length];
            Array.Copy(data, offset, buffer, 0, length);
            return buffer;
        }
        #endregion
    }
}
