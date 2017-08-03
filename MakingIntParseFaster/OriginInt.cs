using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace MakingIntParseFaster
{
    public class OriginInt
    {
        [Pure]
        public static int Parse(String s)
        {
            return NumberV2.ParseInt32(s, NumberFormatInfo.CurrentInfo);
        }

    }
}