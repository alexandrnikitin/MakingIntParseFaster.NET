using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MakingIntParseFaster.V1a
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

            var signState = 0;
            var ret = 0;
            char* next;
            fixed (char* sptr = s)
            {
                var cptr = sptr;
                for (var i = 0; i < 10;)
                {
                    var c = *cptr;
                    if ((uint)(c - '0') <= 9)
                    {
                        signState = 1;
                        ret = ret * 10 + (c - '0');
                        i++;
                        cptr++;
                    }
                    else if (c == '\0')
                    {
                        break;
                    }
                    else if (signState == 0 && (next = MatchChars(cptr, info.PositiveSign)) != null)
                    {
                        signState = 1;
                        cptr = next;
                    }
                    else if (signState == 0 && (next = MatchChars(cptr, info.NegativeSign)) != null)
                    {
                        signState = 2;
                        cptr = next;
                    }
                    // leading whitespaces
                    else if (signState == 0 && IsWhite(c))
                    {
                        cptr++;
                    }
                    // trailing whitespaces
                    else if (IsWhite(c))
                    {
                        break;
                    }
                    else
                    {
                        throw new OverflowException("SR.Format_InvalidString");
                    }
                }

                if (cptr - sptr < s.Length)
                {
                    HandleTrailingWhite(s, sptr, cptr);
                }

            }


            if (signState == 2)
            {
                ret = -ret;
                if (ret > 0)
                {
                    throw new OverflowException("SR.Overflow_Int32");
                }
            }
            else
            {
                if (ret < 0)
                {
                    throw new OverflowException("SR.Overflow_Int32");
                }
            }

            return ret;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static unsafe void HandleTrailingWhite(string s, char* sptr, char* cptr)
        {
            while (true)
            {
                if (!IsWhite(*cptr))
                {
                    if (TrailingZeros(s, (int)(cptr - sptr)))
                    {
                        return;
                    }

                    throw new FormatException("SR.Format_InvalidString");
                }
                cptr++;
            }
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