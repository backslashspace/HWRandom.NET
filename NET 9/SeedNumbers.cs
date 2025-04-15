using System;
using System.Runtime.InteropServices;

namespace BSS.Random
{
    public static partial class HWRandom
    {
        /// <summary>
        /// Calls the RDSEED instruction on a 64 bit register
        /// </summary>
        /// <remarks>The seed values come directly from the entropy conditioner - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-8">intel.com</see></remarks>
        /// <param name="random">value output variable</param>
        /// <returns>Indicated whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if generation failed 128 times in a row</returns>
        [LibraryImport("HWRandomCore", EntryPoint = "ReadSeed64", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial Boolean ReadSeed64(in UInt64 random);

        /// <summary>
        /// Calls the RDSEED instruction on a 32 bit register
        /// </summary>
        /// <remarks>The seed values come directly from the entropy conditioner - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-8">intel.com</see></remarks>
        /// <param name="random">value output variable</param>
        /// <returns>Indicated whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if generation failed 128 times in a row</returns>
        [LibraryImport("HWRandomCore", EntryPoint = "ReadSeed32", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial Boolean ReadSeed32(in UInt32 random);

        /// <summary>
        /// Calls the RDSEED instruction on a 16 bit register
        /// </summary>
        /// <remarks>The seed values come directly from the entropy conditioner - <see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-8">intel.com</see></remarks>
        /// <param name="random">value output variable</param>
        /// <returns>Indicated whether the operation succeeded or not (<see langword="bool"></see> success = <see langword="true"></see>) | will only return false if generation failed 128 times in a row</returns>
        [LibraryImport("HWRandomCore", EntryPoint = "ReadSeed16", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial Boolean ReadSeed16(in UInt16 random);
    }
}