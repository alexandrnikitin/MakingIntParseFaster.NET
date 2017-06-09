using BenchmarkDotNet.Attributes;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
    public class IntParseBenchmarks
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
            return FasterInt.Parse("1");
        }

        [Benchmark]
        public int FasterMaxValue()
        {
            return FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int FasterSign()
        {
            return FasterInt.Parse("-2147483648");
        }

        [Benchmark]
        public int FasterWhitespaces()
        {
            return int.Parse("          -2147483648          ");
        }
    }
}