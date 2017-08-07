using BenchmarkDotNet.Running;
using MakingIntParseFaster.Benchmarks;

namespace MakingIntParseFaster
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<IntParseFasterFullBenchmarks>();
        }
    }
}
