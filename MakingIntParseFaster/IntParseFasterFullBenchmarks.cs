using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
//    [RyuJitX64Job, LegacyJitX86Job, LegacyJitX64Job]
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
        public int OneDigitV1()
        {
            return FasterInt.Parse("1");
        }

        [Benchmark]
        public int FiveDigitsV1()
        {
            return FasterInt.Parse("21474");
        }

        [Benchmark]
        public int MaxValueV1()
        {
            return FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int NegativeOneDigitV1()
        {
            return FasterInt.Parse("-1");
        }

        [Benchmark]
        public int NegativeFiveDigitsV1()
        {
            return FasterInt.Parse("-21474");
        }

        [Benchmark]
        public int NegativeMaxValueV1()
        {
            return FasterInt.Parse("-2147483648");
        }

        [Benchmark]
        public int OneDigitV4()
        {
            return V4.FasterInt.Parse("1");
        }

        [Benchmark]
        public int FiveDigitsV4()
        {
            return V4.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int MaxValueV4()
        {
            return V4.FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int NegativeOneDigitV4()
        {
            return V4.FasterInt.Parse("-1");
        }

        [Benchmark]
        public int NegativeFiveDigitsV4()
        {
            return V4.FasterInt.Parse("-21474");
        }

        [Benchmark]
        public int NegativeMaxValueV4()
        {
            return V4.FasterInt.Parse("-2147483648");
        }

    }
}