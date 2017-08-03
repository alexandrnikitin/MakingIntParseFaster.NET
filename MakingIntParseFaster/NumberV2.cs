using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Text;

namespace MakingIntParseFaster
{
    public class NumberV2
    {
        private const Int32 NumberMaxDigits = 50;
        private const Int32 Int32Precision = 10;
        private const Int32 UInt32Precision = Int32Precision;

        internal unsafe static Int32 ParseInt32(String s, NumberFormatInfo info)
        {
            Byte* numberBufferBytes = stackalloc Byte[NumberBuffer.NumberBufferBytes];
            NumberBuffer number = new NumberBuffer(numberBufferBytes);
            Int32 i = 0;

            StringToNumber(s, ref number, info, false);

            if (!NumberToInt32(ref number, ref i))
            {
                throw new OverflowException("SR.Overflow_Int32");
            }
            return i;
        }

        private unsafe static void StringToNumber(String str, ref NumberBuffer number, NumberFormatInfo info, Boolean parseDecimal)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(String));
            }
            Contract.EndContractBlock();
            Debug.Assert(info != null, "");
            fixed (char* stringPointer = str)
            {
                char* p = stringPointer;
                if (!ParseNumber(ref p, ref number, null, info, parseDecimal)
                    || (p - stringPointer < str.Length && !TrailingZeros(str, (int)(p - stringPointer))))
                {
                    throw new FormatException("SR.Format_InvalidString");
                }
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


        private unsafe static Boolean ParseNumber(ref char* str, ref NumberBuffer number, StringBuilder sb, NumberFormatInfo numfmt, Boolean parseDecimal)
        {
            const Int32 StateSign = 0x0001;
            const Int32 StateParens = 0x0002;
            const Int32 StateDigits = 0x0004;
            const Int32 StateNonZero = 0x0008;
            const Int32 StateDecimal = 0x0010;
            const Int32 StateCurrency = 0x0020;

            number.scale = 0;
            number.sign = false;
            string currSymbol = null;       // currency symbol from NumberFormatInfo.

            Int32 state = 0;
            Boolean bigNumber = (sb != null); // When a StringBuilder is provided then we use it in place of the number.digits char[50]
            Int32 maxParseDigits = bigNumber ? Int32.MaxValue : NumberMaxDigits;

            char* p = str;
            char ch = *p;
            char* next;

            while (true)
            {
                // Eat whitespace unless we've found a sign which isn't followed by a currency symbol.
                // "-Kr 1231.47" is legal but "- 1231.47" is not.
                if (!IsWhite(ch) || ((state & StateSign) != 0 && ((state & StateCurrency) == 0 && numfmt.NumberNegativePattern != 2)))
                {
                    if (((state & StateSign) == 0) && ((next = MatchChars(p, numfmt.PositiveSign)) != null || ((next = MatchChars(p, numfmt.NegativeSign)) != null && (number.sign = true))))
                    {
                        state |= StateSign;
                        p = next - 1;
                    }
                    else if (currSymbol != null && (next = MatchChars(p, currSymbol)) != null)
                    {
                        state |= StateCurrency;
                        currSymbol = null;
                        // We already found the currency symbol. There should not be more currency symbols. Set
                        // currSymbol to NULL so that we won't search it again in the later code path.
                        p = next - 1;
                    }
                    else
                    {
                        break;
                    }
                }
                ch = *++p;
            }
            Int32 digCount = 0;
            Int32 digEnd = 0;
            while (true)
            {
                if ((ch >= '0' && ch <= '9'))
                {
                    state |= StateDigits;

                    if (ch != '0' || (state & StateNonZero) != 0)
                    {
                        if (digCount < maxParseDigits)
                        {
                            if (bigNumber)
                                sb.Append(ch);
                            else
                                number.digits[digCount++] = ch;
                            if (ch != '0' || parseDecimal)
                            {
                                digEnd = digCount;
                            }
                        }
                        if ((state & StateDecimal) == 0)
                        {
                            number.scale++;
                        }
                        state |= StateNonZero;
                    }
                    else if ((state & StateDecimal) != 0)
                    {
                        number.scale--;
                    }
                }
                else
                {
                    break;
                }
                ch = *++p;
            }

            number.precision = digEnd;
            if (bigNumber)
                sb.Append('\0');
            else
                number.digits[digEnd] = '\0';
            if ((state & StateDigits) != 0)
            {
                while (true)
                {
                    if (!IsWhite(ch))
                    {
                        if ((((state & StateSign) == 0)) && ((next = MatchChars(p, numfmt.PositiveSign)) != null || (((next = MatchChars(p, numfmt.NegativeSign)) != null) && (number.sign = true))))
                        {
                            state |= StateSign;
                            p = next - 1;
                        }
                        else if (ch == ')' && ((state & StateParens) != 0))
                        {
                            state &= ~StateParens;
                        }
                        else if (currSymbol != null && (next = MatchChars(p, currSymbol)) != null)
                        {
                            currSymbol = null;
                            p = next - 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    ch = *++p;
                }
                if ((state & StateParens) == 0)
                {
                    if ((state & StateNonZero) == 0)
                    {
                        if (!parseDecimal)
                        {
                            number.scale = 0;
                        }
                        if ((state & StateDecimal) == 0)
                        {
                            number.sign = false;
                        }
                    }
                    str = p;
                    return true;
                }
            }
            str = p;
            return false;
        }
        private static Boolean IsWhite(char ch)
        {
            return (((ch) == 0x20) || ((ch) >= 0x09 && (ch) <= 0x0D));
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

        private static Boolean HexNumberToInt32(ref NumberBuffer number, ref Int32 value)
        {
            UInt32 passedValue = 0;
            Boolean returnValue = HexNumberToUInt32(ref number, ref passedValue);
            value = (Int32)passedValue;
            return returnValue;
        }

        private unsafe static Boolean HexNumberToUInt32(ref NumberBuffer number, ref UInt32 value)
        {
            Int32 i = number.scale;
            if (i > UInt32Precision || i < number.precision)
            {
                return false;
            }
            Char* p = number.digits;
            Debug.Assert(p != null, "");

            UInt32 n = 0;
            while (--i >= 0)
            {
                if (n > ((UInt32)0xFFFFFFFF / 16))
                {
                    return false;
                }
                n *= 16;
                if (*p != '\0')
                {
                    UInt32 newN = n;
                    if (*p != '\0')
                    {
                        if (*p >= '0' && *p <= '9')
                        {
                            newN += (UInt32)(*p - '0');
                        }
                        else
                        {
                            if (*p >= 'A' && *p <= 'F')
                            {
                                newN += (UInt32)((*p - 'A') + 10);
                            }
                            else
                            {
                                Debug.Assert(*p >= 'a' && *p <= 'f', "");
                                newN += (UInt32)((*p - 'a') + 10);
                            }
                        }
                        p++;
                    }

                    // Detect an overflow here...
                    if (newN < n)
                    {
                        return false;
                    }
                    n = newN;
                }
            }
            value = n;
            return true;
        }

        private unsafe static Boolean NumberToInt32(ref NumberBuffer number, ref Int32 value)
        {
            Int32 i = number.scale;
            if (i > Int32Precision || i < number.precision)
            {
                return false;
            }
            char* p = number.digits;
            Debug.Assert(p != null, "");
            Int32 n = 0;
            while (--i >= 0)
            {
                if ((UInt32)n > (0x7FFFFFFF / 10))
                {
                    return false;
                }
                n *= 10;
                if (*p != '\0')
                {
                    n += (Int32)(*p++ - '0');
                }
            }
            if (number.sign)
            {
                n = -n;
                if (n > 0)
                {
                    return false;
                }
            }
            else
            {
                if (n < 0)
                {
                    return false;
                }
            }
            value = n;
            return true;
        }




        internal unsafe struct NumberBuffer
        {
            // Enough space for NumberMaxDigit characters plus null and 3 32 bit integers and a pointer
            public static readonly Int32 NumberBufferBytes = 12 + ((NumberMaxDigits + 1) * 2) + IntPtr.Size;

            private Byte* baseAddress;
            public Char* digits;
            public Int32 precision;
            public Int32 scale;
            public Boolean sign;

            public NumberBuffer(Byte* stackBuffer)
            {
                baseAddress = stackBuffer;
                this.digits = (((Char*)stackBuffer) + 6);
                this.precision = 0;
                this.scale = 0;
                this.sign = false;
            }

            public Byte* PackForNative()
            {
                Int32* baseInteger = (Int32*)baseAddress;
                baseInteger[0] = precision;
                baseInteger[1] = scale;
                baseInteger[2] = sign ? 1 : 0;
                return baseAddress;
            }
        }


    }
}