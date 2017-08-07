using BenchmarkDotNet.Attributes;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
    public class IntParseFasterV1ABenchmarks
    {
        [Benchmark]
        public int FiveDigitsV1()
        {
            return FasterInt.Parse("21474");
        }

        [Benchmark]
        public int NegativeFiveDigitsV1()
        {
            return FasterInt.Parse("-21474");
        }

        [Benchmark]
        public int FiveDigitsV1a()
        {
            return V1a.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int NegativeFiveDigitsV1a()
        {
            return V1a.FasterInt.Parse("-21474");
        }

        [Benchmark]
        public int FiveDigitsV4()
        {
            return V4.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int NegativeFiveDigitsV4()
        {
            return V4.FasterInt.Parse("-21474");
        }
    }
}