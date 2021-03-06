﻿using System.Runtime.InteropServices;
using RomTools;

namespace GbcEmulator.Cpu
{
    [StructLayout(LayoutKind.Explicit, Size=16)]
    public class Registers
    {
        [FieldOffset(0)] public ushort AF;
        [FieldOffset(0)] public short SignedAF;
        [FieldOffset(0)] public byte F;
        [FieldOffset(0)] public sbyte SignedF;
        [FieldOffset(1)] public byte A;
        [FieldOffset(1)] public sbyte SignedA;

        [FieldOffset(2)] public ushort BC;
        [FieldOffset(2)] public short SignedBC;
        [FieldOffset(2)] public byte C;
        [FieldOffset(2)] public sbyte SignedC;
        [FieldOffset(3)] public byte B;
        [FieldOffset(3)] public sbyte SignedB;

        [FieldOffset(4)] public ushort DE;
        [FieldOffset(4)] public short SignedDE;  
        [FieldOffset(4)] public byte E;
        [FieldOffset(4)] public sbyte SignedE;
        [FieldOffset(5)] public byte D;
        [FieldOffset(5)] public sbyte SignedD;

        [FieldOffset(6)] public ushort HL;
        [FieldOffset(6)] public short SignedHL;
        [FieldOffset(6)] public byte L;
        [FieldOffset(6)] public sbyte SignedL;
        [FieldOffset(7)] public byte H;
        [FieldOffset(7)] public sbyte SignedH;

        // BUG: Hardcode starting register values somewhere else so they can be changed per implementation!
        [FieldOffset(8)] public ushort SP = 0xFFFE;
        [FieldOffset(8)] public byte SPl;
        [FieldOffset(9)] public byte SPh;

        [FieldOffset(10)] public ushort PC;
        [FieldOffset(10)] public byte PCl;
        [FieldOffset(11)] public byte PCh;

        // Interrupt information: http://www.z80.info/zip/z80-documented.pdf 
        //                        http://landley.net/history/mirror/cpm/z80.html
        [FieldOffset(12)] public bool IFF1;
        [FieldOffset(13)] public bool IFF2;
        [FieldOffset(14)] public byte I;

        // Memory Refresh Register
        [FieldOffset(15)] public byte R;

        /// <summary>
        /// A way to set PC that will auto-decrement the PC after to take account of the for loop increment
        /// </summary>
        public ushort Address
        {
            set { PC = value; PC--; }
        }

        /// <summary>
        /// Zero flag
        /// </summary>
        public bool FlagZ
        {
            get { return F.GetBit(7); }
            set { F = F.SetBit(7, value); }
        }

        /// <summary>
        /// Add/Subtract flag
        /// </summary>
        public bool FlagN
        {
            get { return F.GetBit(6); }
            set { F = F.SetBit(6, value); }
        }

        /// <summary>
        /// Half Carry flag
        /// </summary>
        public bool FlagH
        {
            get { return F.GetBit(5); }
            set { F = F.SetBit(5, value); }
        }

        /// <summary>
        /// Carry flag
        /// </summary>
        public bool FlagC
        {
            get { return F.GetBit(4); }
            set { F = F.SetBit(4, value); }
        }
        public int FlagCInt { get { return FlagC ? 1 : 0; } }
    }
}
