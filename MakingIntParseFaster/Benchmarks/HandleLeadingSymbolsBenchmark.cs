using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace MakingIntParseFaster.Benchmarks
{
    [Config(typeof(Config))]
    public class HandleLeadingSymbolsBenchmark
    {
        private const string OneWhite = " 12345678";
        private const string Whites = "        12345678";
        private const string WhitesSign = "        -12345678";

        [Benchmark]
        public unsafe bool OneWhiteControl()
        {
            fixed (char* sptr = OneWhite)
            {
                var cptr = sptr;
                var eptr = sptr + OneWhite.Length;

                return V5.FasterInt.HandleLeadingSymbolsForBench(ref cptr, eptr, NumberFormatInfo.CurrentInfo);
            }
        }

        [Benchmark]
        public unsafe bool WhitesControl()
        {
            fixed (char* sptr = Whites)
            {
                var cptr = sptr;
                var eptr = sptr + Whites.Length;

                return V5.FasterInt.HandleLeadingSymbolsForBench(ref cptr, eptr, NumberFormatInfo.CurrentInfo);
            }
        }

        [Benchmark]
        public unsafe bool WhitesSignControl()
        {
            fixed (char* sptr = WhitesSign)
            {
                var cptr = sptr;
                var eptr = sptr + WhitesSign.Length;

                return V5.FasterInt.HandleLeadingSymbolsForBench(ref cptr, eptr, NumberFormatInfo.CurrentInfo);
            }
        }

        [Benchmark]
        public unsafe bool OneWhiteExperiment()
        {
            fixed (char* sptr = OneWhite)
            {
                var cptr = sptr;
                var eptr = sptr + OneWhite.Length;

                return V5.FasterInt.HandleLeadingSymbolsV2(ref cptr, eptr, NumberFormatInfo.CurrentInfo);
            }
        }


        [Benchmark]
        public unsafe bool WhitesExperiment()
        {
            fixed (char* sptr = Whites)
            {
                var cptr = sptr;
                var eptr = sptr + Whites.Length;

                return V5.FasterInt.HandleLeadingSymbolsV2(ref cptr, eptr, NumberFormatInfo.CurrentInfo);
            }
        }

        [Benchmark]
        public unsafe bool WhitesSignExperiment()
        {
            fixed (char* sptr = WhitesSign)
            {
                var cptr = sptr;
                var eptr = sptr + WhitesSign.Length;

                return V5.FasterInt.HandleLeadingSymbolsV2(ref cptr, eptr, NumberFormatInfo.CurrentInfo);
            }
        }
    }
}