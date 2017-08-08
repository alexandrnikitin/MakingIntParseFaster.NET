# MakingIntParseFaster.NET
A spike repo to make int.Parse() and co faster

Benchmark results:

 |                     Method |          Job |       Jit | Platform |      Mean |     Error |    StdDev |
 |--------------------------- |------------- |---------- |--------- |----------:|----------:|----------:|
 |                   OneDigit |    RyuJitX64 |    RyuJit |      X64 |  60.23 ns | 0.3770 ns | 0.3342 ns |
 |                 FiveDigits |    RyuJitX64 |    RyuJit |      X64 |  80.10 ns | 0.2044 ns | 0.1812 ns |
 |                   MaxValue |    RyuJitX64 |    RyuJit |      X64 | 106.54 ns | 0.2653 ns | 0.2351 ns |
 |                Whitespaces |    RyuJitX64 |    RyuJit |      X64 | 136.49 ns | 0.3182 ns | 0.2821 ns |
 |           NegativeOneDigit |    RyuJitX64 |    RyuJit |      X64 |  67.54 ns | 0.0686 ns | 0.0573 ns |
 |         NegativeFiveDigits |    RyuJitX64 |    RyuJit |      X64 |  86.73 ns | 0.2789 ns | 0.2609 ns |
 |           NegativeMaxValue |    RyuJitX64 |    RyuJit |      X64 | 116.56 ns | 0.8386 ns | 0.7845 ns |
 |							  |				 |		     |          |           |           |           |
 |           OneDigitImproved |    RyuJitX64 |    RyuJit |      X64 |  21.74 ns | 0.0551 ns | 0.0515 ns |
 |         FiveDigitsImproved |    RyuJitX64 |    RyuJit |      X64 |  25.45 ns | 0.0702 ns | 0.0623 ns |
 |           MaxValueImproved |    RyuJitX64 |    RyuJit |      X64 |  33.51 ns | 0.0995 ns | 0.0831 ns |
 |        WhitespacesImproved |    RyuJitX64 |    RyuJit |      X64 |  68.08 ns | 0.3129 ns | 0.2927 ns |
 |   NegativeOneDigitImproved |    RyuJitX64 |    RyuJit |      X64 |  27.05 ns | 0.1908 ns | 0.1784 ns |
 | NegativeFiveDigitsImproved |    RyuJitX64 |    RyuJit |      X64 |  30.69 ns | 0.0868 ns | 0.0725 ns |
 |   NegativeMaxValueImproved |    RyuJitX64 |    RyuJit |      X64 |  39.20 ns | 0.1538 ns | 0.1439 ns |

Three loop version results:

 |            Method |     Mean |     Error |    StdDev |
 |------------------ |---------:|----------:|----------:|
 |    FasterOneDigit | 30.64 ns | 0.9426 ns | 0.2448 ns |
 |    FasterMaxValue | 35.97 ns | 0.4189 ns | 0.1088 ns |
 |        FasterSign | 45.19 ns | 2.0742 ns | 0.5388 ns |
 | FasterWhitespaces | 59.93 ns | 9.3043 ns | 2.4168 ns |


 Full:

 ``` ini

BenchmarkDotNet=v0.10.7, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4600U CPU 2.10GHz (Haswell), ProcessorCount=4
Frequency=2630632 Hz, Resolution=380.1368 ns, Timer=TSC
  [Host]       : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2101.1
  LegacyJitX64 : Clr 4.0.30319.42000, 64bit LegacyJIT/clrjit-v4.7.2101.1;compatjit-v4.7.2101.1
  LegacyJitX86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2101.1
  RyuJitX64    : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2101.1

Runtime=Clr  

```
 |                     Method |          Job |       Jit | Platform |      Mean |     Error |    StdDev |
 |--------------------------- |------------- |---------- |--------- |----------:|----------:|----------:|
 |                   OneDigit | LegacyJitX64 | LegacyJit |      X64 |  60.20 ns | 0.3781 ns | 0.2952 ns |
 |                 FiveDigits | LegacyJitX64 | LegacyJit |      X64 |  80.12 ns | 0.3401 ns | 0.3015 ns |
 |                   MaxValue | LegacyJitX64 | LegacyJit |      X64 | 104.04 ns | 0.1720 ns | 0.1437 ns |
 |                Whitespaces | LegacyJitX64 | LegacyJit |      X64 | 132.52 ns | 1.9592 ns | 1.8326 ns |
 |           NegativeOneDigit | LegacyJitX64 | LegacyJit |      X64 |  65.70 ns | 0.2101 ns | 0.1966 ns |
 |         NegativeFiveDigits | LegacyJitX64 | LegacyJit |      X64 |  85.65 ns | 0.1263 ns | 0.0986 ns |
 |           NegativeMaxValue | LegacyJitX64 | LegacyJit |      X64 | 113.73 ns | 1.6895 ns | 1.5803 ns |
 |           OneDigitImproved | LegacyJitX64 | LegacyJit |      X64 |  20.46 ns | 0.0458 ns | 0.0382 ns |
 |         FiveDigitsImproved | LegacyJitX64 | LegacyJit |      X64 |  24.18 ns | 0.0167 ns | 0.0140 ns |
 |           MaxValueImproved | LegacyJitX64 | LegacyJit |      X64 |  34.09 ns | 0.0573 ns | 0.0478 ns |
 |        WhitespacesImproved | LegacyJitX64 | LegacyJit |      X64 |  70.27 ns | 0.0550 ns | 0.0459 ns |
 |   NegativeOneDigitImproved | LegacyJitX64 | LegacyJit |      X64 |  26.19 ns | 0.0816 ns | 0.0723 ns |
 | NegativeFiveDigitsImproved | LegacyJitX64 | LegacyJit |      X64 |  29.48 ns | 0.3140 ns | 0.2622 ns |
 |   NegativeMaxValueImproved | LegacyJitX64 | LegacyJit |      X64 |  38.43 ns | 0.1757 ns | 0.1558 ns |
 |                   OneDigit | LegacyJitX86 | LegacyJit |      X86 |  73.09 ns | 0.1296 ns | 0.1082 ns |
 |                 FiveDigits | LegacyJitX86 | LegacyJit |      X86 |  93.10 ns | 0.3068 ns | 0.2870 ns |
 |                   MaxValue | LegacyJitX86 | LegacyJit |      X86 | 118.83 ns | 0.1972 ns | 0.1748 ns |
 |                Whitespaces | LegacyJitX86 | LegacyJit |      X86 | 148.77 ns | 0.1855 ns | 0.1549 ns |
 |           NegativeOneDigit | LegacyJitX86 | LegacyJit |      X86 |  76.81 ns | 0.0619 ns | 0.0517 ns |
 |         NegativeFiveDigits | LegacyJitX86 | LegacyJit |      X86 |  97.70 ns | 0.2516 ns | 0.2231 ns |
 |           NegativeMaxValue | LegacyJitX86 | LegacyJit |      X86 | 123.78 ns | 0.2113 ns | 0.1764 ns |
 |           OneDigitImproved | LegacyJitX86 | LegacyJit |      X86 |  23.46 ns | 0.0748 ns | 0.0700 ns |
 |         FiveDigitsImproved | LegacyJitX86 | LegacyJit |      X86 |  31.71 ns | 0.1922 ns | 0.1605 ns |
 |           MaxValueImproved | LegacyJitX86 | LegacyJit |      X86 |  43.20 ns | 0.0227 ns | 0.0178 ns |
 |        WhitespacesImproved | LegacyJitX86 | LegacyJit |      X86 |  75.07 ns | 0.1204 ns | 0.1067 ns |
 |   NegativeOneDigitImproved | LegacyJitX86 | LegacyJit |      X86 |  26.55 ns | 0.3148 ns | 0.2945 ns |
 | NegativeFiveDigitsImproved | LegacyJitX86 | LegacyJit |      X86 |  34.27 ns | 0.1224 ns | 0.1022 ns |
 |   NegativeMaxValueImproved | LegacyJitX86 | LegacyJit |      X86 |  45.76 ns | 0.1049 ns | 0.0876 ns |
 |                   OneDigit |    RyuJitX64 |    RyuJit |      X64 |  60.23 ns | 0.3770 ns | 0.3342 ns |
 |                 FiveDigits |    RyuJitX64 |    RyuJit |      X64 |  80.10 ns | 0.2044 ns | 0.1812 ns |
 |                   MaxValue |    RyuJitX64 |    RyuJit |      X64 | 106.54 ns | 0.2653 ns | 0.2351 ns |
 |                Whitespaces |    RyuJitX64 |    RyuJit |      X64 | 136.49 ns | 0.3182 ns | 0.2821 ns |
 |           NegativeOneDigit |    RyuJitX64 |    RyuJit |      X64 |  67.54 ns | 0.0686 ns | 0.0573 ns |
 |         NegativeFiveDigits |    RyuJitX64 |    RyuJit |      X64 |  86.73 ns | 0.2789 ns | 0.2609 ns |
 |           NegativeMaxValue |    RyuJitX64 |    RyuJit |      X64 | 116.56 ns | 0.8386 ns | 0.7845 ns |
 |           OneDigitImproved |    RyuJitX64 |    RyuJit |      X64 |  21.74 ns | 0.0551 ns | 0.0515 ns |
 |         FiveDigitsImproved |    RyuJitX64 |    RyuJit |      X64 |  25.45 ns | 0.0702 ns | 0.0623 ns |
 |           MaxValueImproved |    RyuJitX64 |    RyuJit |      X64 |  33.51 ns | 0.0995 ns | 0.0831 ns |
 |        WhitespacesImproved |    RyuJitX64 |    RyuJit |      X64 |  68.08 ns | 0.3129 ns | 0.2927 ns |
 |   NegativeOneDigitImproved |    RyuJitX64 |    RyuJit |      X64 |  27.05 ns | 0.1908 ns | 0.1784 ns |
 | NegativeFiveDigitsImproved |    RyuJitX64 |    RyuJit |      X64 |  30.69 ns | 0.0868 ns | 0.0725 ns |
 |   NegativeMaxValueImproved |    RyuJitX64 |    RyuJit |      X64 |  39.20 ns | 0.1538 ns | 0.1439 ns |
