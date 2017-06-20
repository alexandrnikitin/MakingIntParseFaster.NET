# MakingIntParseFaster.NET
A spike repo to make int.Parse() and co faster

Benchmark results:

 |            Method |      Mean |     Error |    StdDev |
 |------------------ |----------:|----------:|----------:|
 |          OneDigit |  60.28 ns | 1.5539 ns | 0.4036 ns |
 |          MaxValue | 105.17 ns | 3.4847 ns | 0.9051 ns |
 |              Sign | 109.57 ns | 4.4545 ns | 1.1570 ns |
 |       Whitespaces | 136.43 ns | 4.3078 ns | 1.1189 ns |
 |    FasterOneDigit |  18.97 ns | 0.6642 ns | 0.1725 ns |
 |    FasterMaxValue |  30.68 ns | 2.4894 ns | 0.6466 ns |
 |        FasterSign |  41.97 ns | 0.9735 ns | 0.2529 ns |
 | FasterWhitespaces | 208.79 ns | 6.2361 ns | 1.6198 ns |

Three loop version results:

 |            Method |     Mean |     Error |    StdDev |
 |------------------ |---------:|----------:|----------:|
 |    FasterOneDigit | 30.64 ns | 0.9426 ns | 0.2448 ns |
 |    FasterMaxValue | 35.97 ns | 0.4189 ns | 0.1088 ns |
 |        FasterSign | 45.19 ns | 2.0742 ns | 0.5388 ns |
 | FasterWhitespaces | 59.93 ns | 9.3043 ns | 2.4168 ns |
