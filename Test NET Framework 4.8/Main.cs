using System;
using BSS.Random;

internal class Program
{
    private static void Main(String[] args)
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

        UInt32 random = 0;
        HWRandom.ReadRandom32(random);

        Span<Byte> bytes = stackalloc Byte[32];
        HWRandom.SeedNextBytes(ref bytes, 0ul, 32ul);

        Console.WriteLine("Hello, World! " + random);
    }
}