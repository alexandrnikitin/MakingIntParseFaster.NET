using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;

namespace MakingIntParseFaster.Benchmarks
{
    [RyuJitX64Job, LegacyJitX86Job, LegacyJitX64Job]
    [MarkdownExporterAttribute.GitHub]
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
        public int OneDigitImproved()
        {
            return V5.FasterInt.Parse("1");
        }

        [Benchmark]
        public int FiveDigitsImproved()
        {
            return V5.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int MaxValueImproved()
        {
            return V5.FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int WhitespacesImproved()
        {
            return V5.FasterInt.Parse("          2147483647          ");
        }

        [Benchmark]
        public int NegativeOneDigitImproved()
        {
            return V5.FasterInt.Parse("-1");
        }

        [Benchmark]
        public int NegativeFiveDigitsImproved()
        {
            return V5.FasterInt.Parse("-21474");
        }

        [Benchmark]
        public int NegativeMaxValueImproved()
        {
            return V5.FasterInt.Parse("-2147483648");
        }

    }
}