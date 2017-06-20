using System;
using System.Diagnostics;
using System.Globalization;

namespace MakingIntParseFaster
{
    public static class FasterIntThreeLoops
    {
        public static int Parse(string str)
        {
            return ParseInt32Fast(str, NumberFormatInfo.CurrentInfo);
        }

        internal unsafe static Int32 ParseInt32Fast(String s, NumberFormatInfo info)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(String));
            }

            var ret = 0;
            var isNegative = false;
            fixed (char* sptr = s)
            {
                char* p = sptr;
                char ch = *p;
                char* next;
                while (true)
                {
                    if (!IsWhite(ch))
                    {
                        if ((next = MatchChars(p, info.PositiveSign)) != null || ((next = MatchChars(p, info.NegativeSign)) != null && (isNegative = true)))
                        {
                            p = next - 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    ch = *++p;
                }

                while (true)
                {
                    if (ch >= '0' && ch <= '9')
                    {
                        ret *= 10;
                        ret += ch - '0';
                    }
                    else
                    {
                        break;
                    }
                    ch = *++p;

                }

                while (true)
                {
                    if (!IsWhite(ch))
                    {
                        break;
                    }
                    ch = *++p;
                }

                if (p - sptr < s.Length && !TrailingZeros(s, (int) (p - sptr)))
                {
                    throw new FormatException();
                }

            }


            if (isNegative)
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