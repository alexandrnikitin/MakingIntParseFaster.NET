using BenchmarkDotNet.Attributes;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
    public class IntParseFasterBenchmarks
    {
        [Benchmark]
        public int OneDigit()
        {
            return FasterInt.Parse("1");
        }

        [Benchmark]
        public int MaxValue()
        {
            return FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int Sign()
        {
            return FasterInt.Parse("-2147483648");
        }

        [Benchmark]
        public int Whitespaces()
        {
            return FasterInt.Parse("          -2147483648          ");
        }

        [Benchmark]
        public int OneDigitV2()
        {
            return V2.FasterInt.Parse("1");
        }

        [Benchmark]
        public int MaxValueV2()
        {
            return V2.FasterInt.Parse("2147483647");
        }

        [Benchmark]
        public int SignV2()
        {
            return V2.FasterInt.Parse("-2147483648");
        }

        [Benchmark]
        public int WhitespacesV2()
        {
            return V2.FasterInt.Parse("          -2147483648          ");
        }
    }
}