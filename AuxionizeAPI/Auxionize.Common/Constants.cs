using System;
using System.Text.RegularExpressions;

namespace Auxionize.Common
{
    public class Constants
    {
        public static Regex EAN_Regex => new Regex(@"^[0-9]{8,13}$");

        public const int CACHE_ENTRY_SLIDING_EXPIRATION_DAY = 1;
        public const int CACHE_ENTRY_SIZE = 1;
        public const int CACHE_SIZE_LIMIT = 2000;
    }
}
