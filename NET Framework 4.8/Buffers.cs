using System;
using System.Runtime.InteropServices;

namespace BSS.Random
{
    public static partial class HWRandom
    {
        [DllImport("HWRandomCore", EntryPoint = "SeedNextBytes", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private unsafe static extern Boolean InternalSeedNextBytes(Byte* buffer, UInt64 offset, UInt64 count);

        [DllImport("HWRandomCore", EntryPoint = "NextBytes", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private unsafe static extern Boolean InternalNextBytes(Byte* buffer, UInt64 offset, UInt64 count);

        /// <summary>
        /// Fills a buffer with RDSEED
        /// </summary>
        /// <remarks>The seed values come directly from the entropy conditioner - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-8">intel.com</see></remarks>
        /// <param name="buffer">array to operate on</param>
        /// <param name="offset">offset</param>
        /// <param name="count">count</param>
        /// <returns>Indicates whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if instruction fails 128 times in a row</returns>
        public unsafe static Boolean SeedNextBytes(ref readonly Byte[] buffer, UInt64 offset, UInt64 count)
        {
            if (buffer == null) return false;

            fixed (Byte* ptr = buffer)
            {
                return InternalSeedNextBytes(ptr, offset, count);
            }
        }

        /// <summary>
        /// Fills a buffer with RDSEED
        /// </summary>
        /// <remarks>The seed values come directly from the entropy conditioner - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-8">intel.com</see></remarks>
        /// <param name="buffer">array to operate on</param>
        /// <param name="offset">offset</param>
        /// <param name="count">count</param>
        /// <returns>Indicates whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if instruction fails 128 times in a row</returns>
        public unsafe static Boolean SeedNextBytes(ref readonly Span<Byte> buffer, UInt64 offset, UInt64 count)
        {
            if (buffer.IsEmpty) return false;

            fixed (Byte* ptr = buffer)
            {
                return InternalSeedNextBytes(ptr, offset, count);
            }
        }

        /********************************************************************/

        /// <summary>
        /// Fills a buffer with RDRAND
        /// </summary>
        /// <remarks>Uses random bits from the pool, which is seeded by the conditioner. An upper bound of 511 128-bit samples will be generated per seed. That is, no more than 511*2=1022 sequential DRNG random numbers will be generated from the same seed value. - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-3-3">intel.com</see></remarks>
        /// <param name="buffer">array to operate on</param>
        /// <param name="offset">offset</param>
        /// <param name="count">count</param>
        /// <returns>Indicates whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if instruction fails 128 times in a row</returns>
        public unsafe static Boolean NextBytes(ref readonly Byte[] buffer, UInt64 offset, UInt64 count)
        {
            if (buffer == null) return false;

            fixed (Byte* ptr = buffer)
            {
                return InternalNextBytes(ptr, offset, count);
            }
        }

        /// <summary>
        /// Fills a buffer with RDRAND
        /// </summary>
        /// <remarks>Uses random bits from the pool, which is seeded by the conditioner. An upper bound of 511 128-bit samples will be generated per seed. That is, no more than 511*2=1022 sequential DRNG random numbers will be generated from the same seed value. - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-3-3">intel.com</see></remarks>
        /// <param name="buffer">array to operate on</param>
        /// <param name="offset">offset</param>
        /// <param name="count">count</param>
        /// <returns>Indicates whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if instruction fails 128 times in a row</returns>
        public unsafe static Boolean NextBytes(ref readonly Span<Byte> buffer, UInt64 offset, UInt64 count)
        {
            if (buffer.IsEmpty) return false;

            fixed (Byte* ptr = buffer)
            {
                return InternalNextBytes(ptr, offset, count);
            }
        }
    }
}