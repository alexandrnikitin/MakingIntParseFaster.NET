﻿using System;
using System.Diagnostics;
using System.Globalization;

namespace MakingIntParseFaster._1b
{
    public static class FasterInt
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

            const int StateSign = 1 << 0;
            const int StateNegative = 1 << 1;
            const int StateDigits = 1 << 2;

            var state = 0;
            var ret = 0;
            fixed (char* sptr = s)
            {
                var cptr = sptr;
                while (cptr < sptr + s.Length && ret >= 0)
                {
                    if ((uint)(*cptr - '0') <= 9 && (state & StateDigits) == 0)
                    {
                        state |= StateSign;
                        ret = ret * 10 + (*cptr - '0');
                    }
                    else if ((state & StateSign) == 0 && MatchChars(cptr, info.NegativeSign) != null)
                    {
                        state |= StateSign | StateNegative;
                    }
                    else if ((state & StateSign) == 0 && MatchChars(cptr, info.PositiveSign) != null)
                    {
                        state |= StateSign;
                    }
                    // leading whitespaces
                    else if (IsWhite(*cptr) && (state & StateSign) == 0)
                    {
                    }
                    // trailing whitespaces
                    else if (IsWhite(*cptr))
                    {
                        state |= StateDigits;
                    }
                    else
                    {
                        throw new OverflowException("SR.Format_InvalidString");
                    }

                    cptr++;
                }
            }


            if ((state & StateNegative) > 0)
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