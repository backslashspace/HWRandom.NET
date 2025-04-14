A library that allows you to call your CPUs RDRAND and RDSEED instructions, by calling native C x86-64 intrinsic functions.

## Features

- Supports .NET 9 & .NET Framework 4.8
- No direct heap allocations (only static functions)
- easy to use
- fast
- supports static linking for newer .NET versions (AOT)
- Span support via `System.Memory` in .NET Framework
- easy compatibility check via build-in function that uses `CPUID`

## Examples

#### To check compatibility
```
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
```

#### To get random numbers form the DRNG pool (RDRAND)
```
// define values
UInt64 random64 = 0;
UInt32 random32 = 0;
UInt16 random16 = 0;

// fill values (passed reference)
HWRandom.ReadRandom64(random64);
HWRandom.ReadRandom32(random32);
HWRandom.ReadRandom16(random16);

Console.WriteLine("rdrand on 64 bit register: " + random64);
Console.WriteLine("rdrand on 32 bit register: " + random32);
Console.WriteLine("rdrand on 16 bit register: " + random16);
```

#### To get random numbers form the ENRNG (RDSEED)
```
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
```

#### Fill Buffers
```
Byte[] normalBytes = new Byte[254];

// use RDRAND to fill buffer
HWRandom.NextBytes(ref bytes, 0ul, 256ul);

Span<Byte> spanBytes = stackalloc Byte[1024];

// use RDSEED to fill stack buffer
HWRandom.SeedNextBytes(ref spanBytes, 0ul, 1024ul);
```

*Use the native.lib for static linking, more info in file [AOT-Static-Linking.txt](./AOT-Static-Linking.txt)*

---

[Intel® Digital Random Number Generator (DRNG) Software Implementation Guide](https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html)