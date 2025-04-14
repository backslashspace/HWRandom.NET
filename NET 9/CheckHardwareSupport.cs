using System;
using System.Runtime.InteropServices;

namespace BSS.Random
{
    /// <summary>
    /// Allows you to use the RDSEED and RDRAND instructions from C# 
    /// </summary>
    public static partial class HWRandom
    {
        [LibraryImport("native.dll", EntryPoint = "GetSupportedInstructions", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.U4)]
        private static partial UInt32 InternalGetSupportedInstructions();

        /// <summary>
        /// Return value of <see cref="GetSupportedInstructions()"/>
        /// </summary>
        public enum SupportedInstructions : UInt32
        {
            /// <summary>No support detected.</summary>
            None = 0,

            /// <summary>RDSEEN and RDRAND are supported.</summary>
            All = 1,

            /// <summary>Only RDRAND is supported.</summary>
            RDRAND = 2
        }

        /// <summary>
        /// Executes the CPUID instruction and checks if RDRAND and RDSEED are implemented.
        /// </summary>
        /// <remarks><see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-undefined">Determining Processor Support for RDRAND and RDSEED - Intel.com</see></remarks>
        public static SupportedInstructions GetSupportedInstructions() => (SupportedInstructions)InternalGetSupportedInstructions();
    }
}