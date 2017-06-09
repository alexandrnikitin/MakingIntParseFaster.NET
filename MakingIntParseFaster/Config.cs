using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace MakingIntParseFaster
{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(new Job
            {
                Run =
                {
                    LaunchCount = 1,
                    WarmupCount = 5,
                    TargetCount = 5

                },
                Env =
                {
                    Jit = Jit.RyuJit,
                    Platform = Platform.X64
                }
            });
        }
    }
}