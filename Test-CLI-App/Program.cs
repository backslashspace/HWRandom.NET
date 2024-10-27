using System;
using BSS.Random;

namespace Test_CLI_App
{
    internal static class Program
    {
        private static void Main()
        {
            if (!HWRandom.HardwareRandomIsPresent())
            {
                Console.WriteLine("RDRAND/RDSEED instruction NOT available on CPU!");
                Environment.Exit(-1);
            }

            // define values
            UInt64 _64RandomBits = 0;
            UInt32 _32RandomBits = 0;
            UInt16 _16RandomBits = 0;
            Byte _8RandomBits = 0;

            // fill values
            HWRandom.ReadRandom64(_64RandomBits);
            HWRandom.ReadRandom32(_32RandomBits);
            HWRandom.ReadRandom16(_16RandomBits);
            HWRandom.ReadRandom8(_8RandomBits);

            Console.WriteLine("rand on 64 bit register: " + _64RandomBits);
            Console.WriteLine("rand on 32 bit register: " + _32RandomBits);
            Console.WriteLine("rand on 16 bit register: " + _16RandomBits);
            Console.WriteLine("rand on 16 bit register (only 8 are returned by native function): " + _8RandomBits);

            Console.WriteLine("\n\n");

            HWRandom.ReadSeed64(_64RandomBits);
            HWRandom.ReadSeed32(_32RandomBits);
            HWRandom.ReadSeed16(_16RandomBits);
            HWRandom.ReadSeed8(_8RandomBits);

            Console.WriteLine("seed on 64 bit register: " + _64RandomBits);
            Console.WriteLine("seed on 32 bit register: " + _32RandomBits);
            Console.WriteLine("seed on 16 bit register: " + _16RandomBits);
            Console.WriteLine("seed on 16 bit register (only 8 are returned by native function): " + _8RandomBits);


            Byte[] bytes = new Byte[254];

            HWRandom.NextBytes(bytes, 0, (UInt64)bytes.LongLength);

            HWRandom.SeedNextBytes(bytes.AsSpan());
        }
    }
}