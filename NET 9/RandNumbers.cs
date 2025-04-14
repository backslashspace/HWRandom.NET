using System;
using System.Runtime.InteropServices;

namespace BSS.Random
{
    public static partial class HWRandom
    {
        /// <summary>
        /// Calls the RDRAND instruction on a 64 bit register
        /// </summary>
        /// <remarks>Returns random bits from the pool, which is seeded by the conditioner. An upper bound of 511 128-bit samples will be generated per seed. That is, no more than 511*2=1022 sequential DRNG random numbers will be generated from the same seed value. - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-3-3">intel.com</see></remarks>
        /// <param name="random">value output variable</param>
        /// <returns>Indicated whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if generation failed 128 times in a row</returns>
        [LibraryImport("native.dll", EntryPoint = "ReadRandom64", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial Boolean ReadRandom64(in UInt64 random);

        /// <summary>
        /// Calls the RDRAND instruction on a 32 bit register
        /// </summary>
        /// <remarks>Returns random bits from the pool, which is seeded by the conditioner. An upper bound of 511 128-bit samples will be generated per seed. That is, no more than 511*2=1022 sequential DRNG random numbers will be generated from the same seed value. - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-3-3">intel.com</see></remarks>
        /// <param name="random">value output variable</param>
        /// <returns>Indicated whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if generation failed 128 times in a row</returns>
        [LibraryImport("native.dll", EntryPoint = "ReadRandom32", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial Boolean ReadRandom32(in UInt32 random);

        /// <summary>
        /// Calls the RDRAND instruction on a 16 bit register
        /// </summary>
        /// <remarks>Returns random bits from the pool, which is seeded by the conditioner. An upper bound of 511 128-bit samples will be generated per seed. That is, no more than 511*2=1022 sequential DRNG random numbers will be generated from the same seed value. - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-3-3">intel.com</see></remarks>
        /// <param name="random">value output variable</param>
        /// <returns>Indicated whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if generation failed 128 times in a row</returns>
        [LibraryImport("native.dll", EntryPoint = "ReadRandom16", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial Boolean ReadRandom16(in UInt16 random);
    }
}