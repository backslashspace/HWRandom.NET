using System;
using BSS.Random;

internal static partial class Program
{
    private unsafe static void Main(String[] args)
    {
        switch (HWRandom.GetSupportedInstructions())
        {
            case HWRandom.SupportedInstructions.None:
                Console.WriteLine("Not supported!");
                return;

            case HWRandom.SupportedInstructions.RDRAND:
                Console.WriteLine("Only RDRAND supported!");
                return;

            case HWRandom.SupportedInstructions.All:
                Console.WriteLine("Fully supported.");
                break;
        }

        UInt64 random = 0;

        Boolean test = HWRandom.ReadSeed64(random);

        Console.WriteLine(test);
        Console.WriteLine(random);

        Span<Byte> bytes = stackalloc Byte[6];

        test = HWRandom.SeedNextBytes(ref bytes, 0ul, (UInt64)bytes.Length);

        Console.WriteLine(test);
        Console.WriteLine(bytes[1]);


        // define values
        UInt64 random64 = 0;
        UInt32 random32 = 0;
        UInt16 random16 = 0;

        // fill values (passed reference)
        HWRandom.ReadSeed64(random64);
        HWRandom.ReadSeed32(random32);
        HWRandom.ReadSeed16(random16);

        Console.WriteLine("rdseed on 64 bit register: " + random64);
        Console.WriteLine("rdseed on 32 bit register: " + random32);
        Console.WriteLine("rdseed on 16 bit register: " + random16);






        Byte[] normalBytes = new Byte[254];

        // use RDRAND to fill buffer
        HWRandom.NextBytes(ref bytes, 0ul, 256ul);

        Span<Byte> spanBytes = stackalloc Byte[1024];

        // use RDSEED to fill stack buffer
        HWRandom.SeedNextBytes(ref spanBytes, 0ul, 1024ul);

    }
}