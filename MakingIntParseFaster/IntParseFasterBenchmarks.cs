using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

namespace MakingIntParseFaster
{
    [Config(typeof(Config))]
//    [RyuJitX64Job, LegacyJitX86Job, LegacyJitX64Job]
    public class IntParseFasterBenchmarks
    {
//        [Benchmark]
        public int OneDigit()
        {
            return FasterInt.Parse("1");
        }

//        [Benchmark]
        public int FiveDigits()
        {
            return FasterInt.Parse("21474");
        }

//        [Benchmark]
        public int MaxValue()
        {
            return FasterInt.Parse("2147483647");
        }

        //[Benchmark]
        public int Sign()
        {
            return FasterInt.Parse("-2147483648");
        }

        //[Benchmark]
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
        public int FiveDigitsV2()
        {
            return V2.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int MaxValueV2()
        {
            return V2.FasterInt.Parse("2147483647");
        }
        [Benchmark]
        public int OneDigitV3()
        {
            return V3.FasterInt.Parse("1");
        }

        [Benchmark]
        public int FiveDigitsV3()
        {
            return V3.FasterInt.Parse("21474");
        }

        [Benchmark]
        public int MaxValueV3()
        {
            return V3.FasterInt.Parse("2147483647");
        }

        //[Benchmark]
        public int SignV2()
        {
            return V2.FasterInt.Parse("-2147483648");
        }

        //[Benchmark]
        public int WhitespacesV2()
        {
            return V2.FasterInt.Parse("          -2147483648          ");
        }
    }
}