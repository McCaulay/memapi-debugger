using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMAPI_Debugger.MEMAPI
{
    public class Registers
    {
        public ulong r15 { get; set; }
        public ulong r14 { get; set; }
        public ulong r13 { get; set; }
        public ulong r12 { get; set; }
        public ulong r11 { get; set; }
        public ulong r10 { get; set; }
        public ulong r9 { get; set; }
        public ulong r8 { get; set; }
        public ulong rdi { get; set; }
        public ulong rsi { get; set; }
        public ulong rbp { get; set; }
        public ulong rbx { get; set; }
        public ulong rdx { get; set; }
        public ulong rcx { get; set; }
        public ulong rax { get; set; }
        public uint trapno { get; set; }
        public ushort fs { get; set; }
        public ushort gs { get; set; }
        public uint err { get; set; }
        public ushort es { get; set; }
        public ushort ds { get; set; }
        public ulong rip { get; set; }
        public ulong cs { get; set; }
        public ulong rflags { get; set; }
        public ulong rsp { get; set; }
        public ulong ss { get; set; }

        public Registers()
        {
            r15 = 0; r14 = 0; r13 = 0; r12 = 0; r11 = 0;
            r10 = 0; r9 = 0; r8 = 0; rdi = 0; rsi = 0;
            rbp = 0; rbx = 0; rdx = 0; rcx = 0; rax = 0;
            trapno = 0; fs = 0; gs = 0; err = 0; es = 0;
            ds = 0; rip = 0; cs = 0; rflags = 0; rsp = 0;
            ss = 0;
        }
    }
}
