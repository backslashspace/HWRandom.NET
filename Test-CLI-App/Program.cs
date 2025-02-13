using System;
using BSS.Random;

namespace Test_CLI_App
{
    internal static class Program
    {
        private static void Main()
        {
            HWRandom.SupportedInstructions supportedInstructions = HWRandom.GetSupportedInstructions();

            String message = supportedInstructions switch
            {
                HWRandom.SupportedInstructions.All => "All instruction are available on CPU!",
                HWRandom.SupportedInstructions.RDRAND => "RDRAND instruction is available on CPU!",
                HWRandom.SupportedInstructions.None => "RDRAND/RDSEED instruction NOT available on CPU!",
                _ => throw new NotImplementedException(),
            };

            Console.WriteLine(message);

            if (supportedInstructions == HWRandom.SupportedInstructions.None) Environment.Exit(-1);

            // define values
            UInt64 _64RandomBits = 0;
            UInt32 _32RandomBits = 0;
            UInt16 _16RandomBits = 0;

            // fill values
            HWRandom.ReadRandom64(_64RandomBits);
            HWRandom.ReadRandom32(_32RandomBits);
            HWRandom.ReadRandom16(_16RandomBits);

            Console.WriteLine("rand on 64 bit register: " + _64RandomBits);
            Console.WriteLine("rand on 32 bit register: " + _32RandomBits);
            Console.WriteLine("rand on 16 bit register: " + _16RandomBits);

            Console.WriteLine("\n\n");

            HWRandom.ReadSeed64(_64RandomBits);
            HWRandom.ReadSeed32(_32RandomBits);
            HWRandom.ReadSeed16(_16RandomBits);

            Console.WriteLine("seed on 64 bit register: " + _64RandomBits);
            Console.WriteLine("seed on 32 bit register: " + _32RandomBits);
            Console.WriteLine("seed on 16 bit register: " + _16RandomBits);

            Byte[] bytes = new Byte[254];

            HWRandom.NextBytes(bytes, 0, bytes.Length);
            HWRandom.SeedNextBytes(bytes, 0, bytes.Length);

            Span<Byte> span = new Byte[43].AsSpan();

            HWRandom.NextBytes(span);
            HWRandom.SeedNextBytes(span);

            //#########

           
        }
    }
}