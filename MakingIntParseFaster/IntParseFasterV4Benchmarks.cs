using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
    public class IntParseFasterV4Benchmarks
    {
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

        [Benchmark]
        public int FiveDigitsV4a()
        {
            return V4a.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int NegativeFiveDigitsV4a()
        {
            return V4a.FasterInt.Parse("-21474");
        }
    }
}