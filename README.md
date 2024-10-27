# HWRand.Net

A small .Net Framework 4.8 library that allows you to *directly* call your CPUs RDRAND and RDSEED instructions, this is done by calling a C wrapper for x86-64 assembly with P/Invoke.

## Features

- No direct heap allocations (only static functions)
- easy to use
- Span support via `System.Memory`
- easy compatibility check via build-in function that uses `CPUID`

## How to Use

#### To check compatibility
```
if (HWRandom.HardwareRandomIsPresent())
{
    Console.WriteLine("CPU compatible!");
    Worker.Start();

    Environment.Exit(0);
}
else
{
    Console.WriteLine("RDRAND/RDSEED instruction NOT available on CPU!");
    Environment.Exit(-1);
}
```

#### To get random numbers form the DRNG pool (RDRAND)
```
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
```

#### To get random numbers form the ENRNG (RDSEED)
```
// define values
UInt64 _64RandomBits = 0;
UInt32 _32RandomBits = 0;
UInt16 _16RandomBits = 0;
Byte _8RandomBits = 0;

// fill values
HWRandom.ReadSeed64(_64RandomBits);
HWRandom.ReadSeed32(_32RandomBits);
HWRandom.ReadSeed16(_16RandomBits);
HWRandom.ReadSeed8(_8RandomBits);

Console.WriteLine("seed on 64 bit register: " + _64RandomBits);
Console.WriteLine("seed on 32 bit register: " + _32RandomBits);
Console.WriteLine("seed on 16 bit register: " + _16RandomBits);
Console.WriteLine("seed on 16 bit register (only 8 are returned by native function): " + _8RandomBits);
```

#### To fill a buffer
```
Byte[] bytes = new Byte[254];

// use RDRAND to fill buffer
HWRandom.NextBytes(bytes, 0, (UInt64)bytes.LongLength);

// use RDSEED to fill buffer
HWRandom.SeedNextBytes(bytes.AsSpan());
```
---

[Intel® Digital Random Number Generator (DRNG) Software Implementation Guide](https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html)