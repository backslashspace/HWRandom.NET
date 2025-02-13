#include <intrin.h> 

#define bool unsigned __int8
#define true 1
#define false 0

#define uint8 unsigned __int8
#define uint32 unsigned __int32
#define uint16 unsigned __int16
#define uint64 unsigned __int64

// # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

typedef struct {
    uint32 EAX;
    uint32 EBX;
    uint32 ECX;
    uint32 EDX;
} CPUID;

// 1 = all supported
// 2 = only rdrand
// 0 = none

__declspec(dllexport) uint32 GetSupportedInstructions()
{
    CPUID cpuId = { 0, 0, 0, 0};

    __cpuid(&cpuId, 1);

    bool rdrand = (cpuId.ECX & ((uint32)1 << 30)) != 0;

    __cpuid(&cpuId, 7);

    bool rdseed = (cpuId.EBX & ((uint32)1 << 18)) != 0;

    if (rdseed) return 1;
    if (!rdseed && rdrand) return 2;
    return 0;
}

// # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

__declspec(dllexport) bool ReadSeed16(uint16* random)
{
    for (uint16 i = 0; i < 128; ++i)
    {
        if (_rdseed16_step(random)) return 1;
    }

    return 0;
}

__declspec(dllexport) bool ReadSeed32(uint32* random)
{
    for (uint16 i = 0; i < 128; ++i)
    {
        if (_rdseed32_step(random)) return 1;
    }

    return 0;
}

__declspec(dllexport) bool ReadSeed64(uint64* random)
{
    for (uint16 i = 0; i < 128; ++i)
    {
        if (_rdseed64_step(random)) return 1;
    }

    return 0;
}

__declspec(dllexport) bool ReadRandom16(uint16* random)
{
    for (uint16 i = 0; i < 128; ++i)
    {
        if (_rdrand16_step(random)) return 1;
    }

    return 0;
}

__declspec(dllexport) bool ReadRandom32(uint32* random)
{
    for (uint16 i = 0; i < 128; ++i)
    {
        if (_rdrand32_step(random)) return 1;
    }

    return 0;
}

__declspec(dllexport) bool ReadRandom64(uint64* random)
{
    for (uint16 i = 0; i < 128; ++i)
    {
        if (_rdrand64_step(random)) return 1;
    }

    return 0;
}