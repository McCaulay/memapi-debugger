using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger.MEMAPI
{
    public static class Server
    {
        public static Queue<string> lines;
        private static int MAX_LINES = 5000;

        private static System.Threading.Thread thread;
        private static TcpListener listener;
        private static TcpClient client;
        private static NetworkStream stream;

        // Data changed event
        public static event EventHandler ServerQueueUpdated;

        static Server()
        {
            lines = new Queue<string>();
            thread = new System.Threading.Thread(listen);
            thread.IsBackground = true;
            listener = new TcpListener(IPAddress.Any, 9023);
        }

        public static void start()
        {
            listener.Start();
            thread.Start();
        }

        private static void listen()
        {
            byte[] buffer = new byte[512];
            int length = 0;
            string result = "";

            // Keep listening forever
            while (true)
            {
                // Accept a connection and get it's stream
                client = listener.AcceptTcpClient();
                stream = client.GetStream();

                // While it's sending data, add it to the lines list
                do
                {
                    buffer = new byte[512];
                    length = stream.Read(buffer, 0, buffer.Length);
                    result = System.Text.Encoding.UTF8.GetString(buffer).Trim('\0');
                    addLines(result.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
                }
                while (length > 0);

            }
        }

        private static void addLines(string[] strings)
        {
            // Add lines to queue
            for (int i = 0; i < strings.Length; i++)
            {
                string toAdd = strings[i];
                toAdd = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + toAdd;
                lines.Enqueue(toAdd);
            }

            // Remove lines from queue if greater than MAX_LINES
            if (lines.Count > MAX_LINES)
            {
                for (int i = 0; i < lines.Count - MAX_LINES; i++)
                    lines.Dequeue();
            }

            OnServerQueueUpdated(EventArgs.Empty);
        }

        private static void OnServerQueueUpdated(EventArgs e)
        {
            EventHandler handler = ServerQueueUpdated;
            if (handler != null)
                handler(null, e);
        }
    }
}
