using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
    [MarkdownExporterAttribute.GitHub]
    public class IntParseSignsBenchmarks
    {
        [Benchmark]
        public int FasterOneDigit()
        {
            return FasterIntSigns.Parse("1");
        }

        [Benchmark]
        public int FasterMaxValue()
        {
            return FasterIntSigns.Parse("2147483647");
        }

        [Benchmark]
        public int FasterSign()
        {
            return FasterIntSigns.Parse("-2147483648");
        }

        [Benchmark]
        public int FasterWhitespaces()
        {
            return FasterIntSigns.Parse("          -2147483648          ");
        }
    }
}