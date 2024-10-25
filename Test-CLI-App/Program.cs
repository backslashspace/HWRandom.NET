using System;
using BSS.Random;

namespace Test_CLI_App
{
    internal static class Program
    {
     



        private unsafe static void Main()
        {
            if (!HWRandom.HardwareRandomIsPresent())
            {
                Console.WriteLine("RDRAND/RDSEED instruction NOT available on CPU!");
                Environment.Exit(-1);
            }

            UInt64 val64 = 0;
            UInt32 value32 = 0;
            UInt16 value16 = 0;
            Byte value8 = 0;

            HWRandom.ReadRandom64(val64);
            HWRandom.ReadRandom32(value32);
            HWRandom.ReadRandom16(value16);
            HWRandom.ReadRandom8(value8);

            Console.WriteLine("rand 64: " + val64);
            Console.WriteLine("rand 32: " + value32);
            Console.WriteLine("rand 16: " + value16);
            Console.WriteLine("rand 8: " + value8);

            //

            HWRandom.ReadSeed64(val64);
            HWRandom.ReadSeed32(value32);
            HWRandom.ReadSeed16(value16);
            HWRandom.ReadSeed8(value8);

            Console.WriteLine("seed 64: " + val64);
            Console.WriteLine("seed 32: " + value32);
            Console.WriteLine("seed 16: " + value16);
            Console.WriteLine("seed 8: " + value8);


        }
    }
}