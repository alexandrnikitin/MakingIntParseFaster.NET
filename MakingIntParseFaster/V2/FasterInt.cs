using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MakingIntParseFaster.V2
{
    public static class FasterInt
    {
        public static int Parse(string str)
        {
            return ParseInt32Fast(str, NumberFormatInfo.CurrentInfo);
        }

        internal unsafe static Int32 ParseInt32Fast(String s, NumberFormatInfo info)
        {
            if (s == null) throw new ArgumentNullException(nameof(String));
            var ret = 0;
            fixed (char* sptr = s)
            {
                var cptr = sptr;

                if (!((uint)(*cptr - '0') <= 9))
                {
                    // TODO should throw!
                    cptr = HandleNonNum(cptr, info);
                }

                // iterate over nums
                while (true)
                {
                    if ((uint)(*cptr - '0') <= 9)
                    {
                        ret = ret * 10 + (*cptr - '0');
                        cptr++;
                    }
                    else if (*cptr == '\0')
                    {
                        break;
                    }
                    else
                    {
                        // check for trailing symbols
                        // TODO should throw!
                        HandleTrailing(cptr);
                        break;
                    }
                }
            }

            return ret;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static unsafe void HandleTrailing(char* cptr)
        {
            throw new NotImplementedException();
        }

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
        private static unsafe char* HandleNonNum(char* cptr, NumberFormatInfo info)
        {
            // check current for white
            if (IsWhite(*cptr))
            {
                cptr = SkipLeadingWhites(cptr);
            }

            // check current for sign
            if (*cptr < '0')
            {
                cptr = HandleSign(cptr, info);
            }

            return cptr;
        }

        private static unsafe char* HandleSign(char* cptr, NumberFormatInfo info)
        {
            var matchChars = MatchChars(cptr, info.NegativeSign);
            if (matchChars != null)
            {
                return matchChars;
            }

            matchChars = MatchChars(cptr, info.PositiveSign);
            if (matchChars != null)
            {
                return matchChars;
            }

            return cptr;
        }

        private static unsafe char* SkipLeadingWhites(char* cptr)
        {
            while (IsWhite(*cptr))
            {
                cptr++;
            }

            return cptr;
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