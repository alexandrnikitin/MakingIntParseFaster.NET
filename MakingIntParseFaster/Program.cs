using System;
using System.Globalization;
using BenchmarkDotNet.Running;

namespace MakingIntParseFaster
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<OriginalIntParseBenchmarks>();
        }
    }
}
