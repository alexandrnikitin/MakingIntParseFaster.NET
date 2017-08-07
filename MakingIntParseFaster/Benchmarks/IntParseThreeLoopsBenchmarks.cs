using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace MakingIntParseFaster.Benchmarks
{
    [Config(typeof(Config))]
    [MarkdownExporterAttribute.GitHub]
    public class IntParseThreeLoopsBenchmarks
    {
        [Benchmark]
        public int FasterOneDigit()
        {
            return FasterIntThreeLoops.Parse("1");
        }

        [Benchmark]
        public int FasterMaxValue()
        {
            return FasterIntThreeLoops.Parse("2147483647");
        }

        [Benchmark]
        public int FasterSign()
        {
            return FasterIntThreeLoops.Parse("-2147483648");
        }

        [Benchmark]
        public int FasterWhitespaces()
        {
            return FasterIntThreeLoops.Parse("          -2147483648          ");
        }
    }
}