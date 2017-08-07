using BenchmarkDotNet.Attributes;

namespace MakingIntParseFaster.Benchmarks
{
    public class VariousBenchmarks
    {
        [Benchmark]
        public unsafe int Fixes()
        {
            var sum = 0;
            fixed (char* sptr = "1234567890")
            {
                var cptr = sptr;
                while((uint)(*cptr - '0') <= 9)
                {
                    sum += (*cptr - '0');
                    cptr++;
                }
            }

            return sum;
        }
    }
}