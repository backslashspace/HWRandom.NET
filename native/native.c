#include <intrin.h>

#define bool unsigned __int8
#define true 1
#define false 0

#define uint8 unsigned __int8
#define uint32 unsigned __int32
#define uint16 unsigned __int16
#define uint64 unsigned __int64

// # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

extern bool InternalReadRandom64(uint64* outValue);
extern bool InternalReadRandom32(uint32* outValue);
extern bool InternalReadRandom16(uint16* outValue);
extern bool InternalReadRandom8(uint8* outValue);

extern bool InternalReadSeed64(uint64* outValue);
extern bool InternalReadSeed32(uint32* outValue);
extern bool InternalReadSeed16(uint16* outValue);
extern bool InternalReadSeed8(uint8* outValue);

// # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

typedef struct {
    unsigned __int32 EAX;
    unsigned __int32 EBX;
    unsigned __int32 ECX;
    unsigned __int32 EDX;
} CPUID;

__declspec(dllexport) bool HardwareRandomIsPresent()
{
    CPUID cpuID;

    __cpuid(&cpuID, 1);

    if (!((cpuID.ECX & 0x40000000) == 0x40000000))
    {
        return 0;
    }

    __cpuid(&cpuID, 7);

    if (!(cpuID.EBX & 0x40000) == 0x40000)
    {
        return 0;
    }

    return 1;
}

// # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

__declspec(dllexport) bool ReadRandom64(uint64* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadRandom64(random))
        {
            return true;
        }
    }

    return false;
}

__declspec(dllexport) bool ReadRandom32(uint32* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadRandom32(random))
        {
            return true;
        }
    }

    return false;
}

__declspec(dllexport) bool ReadRandom16(uint16* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadRandom16(random))
        {
            return true;
        }
    }

    return false;
}

__declspec(dllexport) bool ReadRandom8(uint8* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadRandom8(random))
        {
            return true;
        }
    }

    return false;
}

// # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #

__declspec(dllexport) bool ReadSeed64(uint64* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadSeed64(random))
        {
            return true;
        }
    }

    return false;
}

__declspec(dllexport) bool ReadSeed32(uint32* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadSeed32(random))
        {
            return true;
        }
    }

    return false;
}

__declspec(dllexport) bool ReadSeed16(uint16* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadSeed16(random))
        {
            return true;
        }
    }

    return false;
}

__declspec(dllexport) bool ReadSeed8(uint8* random)
{
    for (uint8 i = 0; i < 128; ++i)
    {
        if (InternalReadSeed8(random))
        {
            return true;
        }
    }

    return false;
}