#include <intrin.h>

#define true 1
#define false 0
typedef unsigned __int8 bool;

typedef unsigned __int8 uint8;
typedef unsigned __int32 uint32;
typedef unsigned __int16 uint16;
typedef unsigned __int64 uint64;

/*************************** CPU SUPPORT ****************************/

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
    bool rdrand;
    bool rdseed;
    CPUID cpuId = { 0, 0, 0, 0 };

    __cpuid((uint32*)&cpuId, 1);
    rdrand = (cpuId.ECX & ((uint32)1 << 30)) != 0;

    __cpuid((uint32*)&cpuId, 7);
    rdseed = (cpuId.EBX & ((uint32)1 << 18)) != 0;

    if (rdseed) return 1;
    if (!rdseed && rdrand) return 2;
    return 0;
}

/***************************** NUMBERS ******************************/

__declspec(dllexport) bool ReadSeed16(uint16* random)
{
    uint16 counter = 0;

RETRY:
    if (_rdseed16_step(random)) return 1;

    if (++counter == 128) return 0;
    else goto RETRY;
}

__declspec(dllexport) bool ReadSeed32(uint32* random)
{
    uint16 counter = 0;

RETRY:
    if (_rdseed32_step(random)) return 1;

    if (++counter == 128) return 0;
    else goto RETRY;
}

__declspec(dllexport) bool ReadSeed64(uint64* random)
{
    uint16 counter = 0;

RETRY:
    if (_rdseed64_step(random)) return 1;

    if (++counter == 128) return 0;
    else goto RETRY;
}

__declspec(dllexport) bool ReadRandom16(uint16* random)
{
    uint16 counter = 0;

RETRY:
    if (_rdrand16_step(random)) return 1;

    if (++counter == 128) return 0;
    else goto RETRY;
}

__declspec(dllexport) bool ReadRandom32(uint32* random)
{
    uint16 counter = 0;

RETRY:
    if (_rdrand32_step(random)) return 1;

    if (++counter == 128) return 0;
    else goto RETRY;
}

__declspec(dllexport) bool ReadRandom64(uint64* random)
{
    uint16 counter = 0;

RETRY:
    if (_rdrand64_step(random)) return 1;

    if (++counter == 128) return 0;
    else goto RETRY;
}

/***************************** BUFFERS ******************************/

typedef union
{
    uint64 Input64;
    uint32 Input32;
    uint16 Input16;

    char Output[8];
} UInt64ByteView;

__declspec(dllexport) bool SeedNextBytes(char* buffer, uint64 offset, uint64 count)
{
    if (count == 0) return 1;

    UInt64ByteView dataView;

    uint64 counter = offset;
    uint64 counterMax = offset + count;

    do
    {
        if (counter + 8 <= counterMax)
        {
            if (!ReadSeed64(&dataView.Input64)) return false;

            buffer[counter] = dataView.Output[0];
            buffer[++counter] = dataView.Output[1];
            buffer[++counter] = dataView.Output[2];
            buffer[++counter] = dataView.Output[3];
            buffer[++counter] = dataView.Output[4];
            buffer[++counter] = dataView.Output[5];
            buffer[++counter] = dataView.Output[6];
            buffer[++counter] = dataView.Output[7];
        }
        else if (counter + 4 <= counterMax)
        {
            if (!ReadSeed32(&dataView.Input32)) return false;

            buffer[counter] = dataView.Output[0];
            buffer[++counter] = dataView.Output[1];
            buffer[++counter] = dataView.Output[2];
            buffer[++counter] = dataView.Output[3];
        }
        else if (counter + 2 <= counterMax)
        {
            if (!ReadSeed16(&dataView.Input16)) return false;

            buffer[counter] = dataView.Output[0];
            buffer[++counter] = dataView.Output[1];
        }
        else
        {
            if (!ReadSeed16(&dataView.Input16)) return false;

            buffer[counter] = dataView.Output[0];
        }

        ++counter;
    }
    while (counter < counterMax);

    return true;
}

__declspec(dllexport) bool NextBytes(char* buffer, uint64 offset, uint64 count)
{
    if (count == 0) return 1;

    UInt64ByteView dataView;

    uint64 counter = offset;
    uint64 counterMax = offset + count;

    do
    {
        if (counter + 8 <= counterMax)
        {
            if (!ReadRandom64(&dataView.Input64)) return false;

            buffer[counter] = dataView.Output[0];
            buffer[++counter] = dataView.Output[1];
            buffer[++counter] = dataView.Output[2];
            buffer[++counter] = dataView.Output[3];
            buffer[++counter] = dataView.Output[4];
            buffer[++counter] = dataView.Output[5];
            buffer[++counter] = dataView.Output[6];
            buffer[++counter] = dataView.Output[7];
        }
        else if (counter + 4 <= counterMax)
        {
            if (!ReadRandom32(&dataView.Input32)) return false;

            buffer[counter] = dataView.Output[0];
            buffer[++counter] = dataView.Output[1];
            buffer[++counter] = dataView.Output[2];
            buffer[++counter] = dataView.Output[3];
        }
        else if (counter + 2 <= counterMax)
        {
            if (!ReadRandom16(&dataView.Input16)) return false;

            buffer[counter] = dataView.Output[0];
            buffer[++counter] = dataView.Output[1];
        }
        else
        {
            if (!ReadRandom16(&dataView.Input16)) return false;

            buffer[counter] = dataView.Output[0];
        }

        ++counter;
    } while (counter < counterMax);

    return true;
}