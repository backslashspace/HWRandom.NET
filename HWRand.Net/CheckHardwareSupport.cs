using System;
using System.Runtime.InteropServices;

namespace BSS.Random
{
    public static partial class HWRandom
    {
        /// <summary>
        /// Executes the CPUID instruction and checks if RDRAND and RDSEED are implemented.
        /// </summary>
        /// <remarks><see href="https://www.intel.com/content/www/us/en/developer/articles/guide/intel-digital-random-number-generator-drng-software-implementation-guide.html#inpage-nav-5-undefined">Determining Processor Support for RDRAND and RDSEED - Intel.com</see></remarks>
        /// <returns>returns <see langword="bool"/> => implemented = true, not present = false</returns>
        [DllImport("native.dll", EntryPoint = "HardwareRandomIsPresent")]
        public static extern Boolean HardwareRandomIsPresent();
    }
}