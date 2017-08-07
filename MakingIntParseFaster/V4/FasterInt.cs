using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MakingIntParseFaster.V4
{
    public static class FasterInt
    {
        public static int Parse(string str)
        {
            return ParseInt32Fast(str, NumberFormatInfo.CurrentInfo);
        }

        internal static unsafe Int32 ParseInt32Fast(String s, NumberFormatInfo info)
        {
            if (s == null) throw new ArgumentNullException(nameof(String));
            var isNegative = false;
            var ret = 0;
            fixed (char* sptr = s)
            {
                var cptr = sptr;

                if (!((uint)(*cptr - '0') <= 9))
                {
                    isNegative = HandleLeadingSymbols(ref cptr, info);
                }

                // iterate over nums
                for (var i = 0; i < 10; i++)
                {
                    if ((uint)(*cptr - '0') <= 9)
                    {
                        ret = ret * 10 + (*cptr - '0');
                        cptr++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (cptr - sptr < s.Length)
                {
                    HandleTrailingWhite(s, sptr, cptr);
                }
            }

            if (isNegative)
            {
                ret = -ret;
                if (ret > 0) throw new OverflowException("SR.Overflow_Int32");
            }
            else
            {
                if (ret < 0) throw new OverflowException("SR.Overflow_Int32");
            }

            return ret;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Boolean TrailingZeros(String s, Int32 index)
        {
            // For compatibility, we need to allow trailing zeros at the end of a number string
            for (int i = index; i < s.Length; i++)
            {
                if (s[i] != '\0')
                {
                    return false;
                }
            }
            return true;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private static unsafe bool HandleLeadingSymbols(ref char* cptr, NumberFormatInfo info)
        {
            var isNegative = false;
            char* next;
            while (true)
            {
                if (!IsWhite(*cptr))
                {
                    if ((next = MatchChars(cptr, info.PositiveSign)) != null || ((next = MatchChars(cptr, info.NegativeSign)) != null && (isNegative = true)))
                    {
                        cptr = next - 1;
                    }
                    else if ((uint)(*cptr - '0') <= 9)
                    {
                        return isNegative;
                    }
                    else
                    {
                        throw new FormatException("SR.Format_InvalidString");
                    }
                }
                cptr++;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static unsafe void HandleTrailingWhite(string s, char* sptr, char* cptr)
        {
            while (true)
            {
                if (!IsWhite(*cptr))
                {
                    if (TrailingZeros(s, (int) (cptr - sptr)))
                    {
                        return;
                    }

                    throw new FormatException("SR.Format_InvalidString");
                }
                cptr++;
            }
        }

        private unsafe static char* MatchChars(char* p, string str)
        {
            fixed (char* stringPointer = str)
            {
                return MatchChars(p, stringPointer);
            }
        }
        private unsafe static char* MatchChars(char* p, char* str)
        {
            Debug.Assert(p != null && str != null, "");

            if (*str == '\0')
            {
                return null;
            }
            // We only hurt the failure case
            // This fix is for French or Kazakh cultures. Since a user cannot type 0xA0 as a
            // space character we use 0x20 space character instead to mean the same.
            while (*p == *str || (*str == '\u00a0' && *p == '\u0020'))
            {
                p++;
                str++;
                if (*str == '\0') return p;
            }
            return null;
        }

        private static Boolean IsWhite(char ch)
        {
            return (((ch) == 0x20) || ((ch) >= 0x09 && (ch) <= 0x0D));
        }
    }
}