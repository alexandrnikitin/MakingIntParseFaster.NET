using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

namespace MakingIntParseFaster.Benchmarks
{
    [RyuJitX64Job, LegacyJitX86Job, LegacyJitX64Job]
    public class IntParseFasterFullBenchmarks
    {
        [Benchmark]
        public int OneDigit()
        {
            return int.Parse("1");
        }

        [Benchmark]
        public int FiveDigits()
        {
            return int.Parse("21474");
        }

        [Benchmark]
        public int MaxValue()
        {
            return int.Parse("2147483647");
        }

        [Benchmark]
        public int Whitespaces()
        {
            return int.Parse("          2147483647          ");
        }

        [Benchmark]
        public int NegativeOneDigit()
        {
            return int.Parse("-1");
        }

        [Benchmark]
        public int NegativeFiveDigits()
        {
            return int.Parse("-21474");
        }

        [Benchmark]
        public int NegativeMaxValue()
        {
            return int.Parse("-2147483648");
        }

        [Benchmark]
        public int OneDigitV5()
        {
            return V5.FasterInt.Parse("1");
        }

        [Benchmark]
        public int FiveDigitsV5()
        {
            return V5.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int MaxValueV5()
        {
            return V5.FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int WhitespacesV5()
        {
            return V5.FasterInt.Parse("          2147483647          ");
        }

        [Benchmark]
        public int NegativeOneDigitV5()
        {
            return V5.FasterInt.Parse("-1");
        }

        [Benchmark]
        public int NegativeFiveDigitsV5()
        {
            return V5.FasterInt.Parse("-21474");
        }

        [Benchmark]
        public int NegativeMaxValueV5()
        {
            return V5.FasterInt.Parse("-2147483648");
        }

    }
}