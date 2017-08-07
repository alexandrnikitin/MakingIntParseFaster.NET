using BenchmarkDotNet.Attributes;

namespace MakingIntParseFaster.Benchmarks
{
    [Config(typeof(Config))]
    public class OriginalIntParseBenchmarks
    {
        [Benchmark]
        public int OneDigit()
        {
            return int.Parse("1");
        }

        [Benchmark]
        public int MaxValue()
        {
            return int.Parse("2147483647");
        }

        [Benchmark]
        public int Sign()
        {
            return int.Parse("-2147483648");
        }

        [Benchmark]
        public int Whitespaces()
        {
            return int.Parse("          -2147483648          ");
        }

        [Benchmark]
        public int FasterOneDigit()
        {
            return OriginInt.Parse("1");
        }

        [Benchmark]
        public int FasterMaxValue()
        {
            return OriginInt.Parse("2147483647");
        }

        [Benchmark]
        public int FasterSign()
        {
            return OriginInt.Parse("-2147483648");
        }

        [Benchmark]
        public int FasterWhitespaces()
        {
            return OriginInt.Parse("          -2147483648          ");
        }
    }
}