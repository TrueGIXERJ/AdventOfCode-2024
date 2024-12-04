using System.Diagnostics;

namespace AdventOfCode2024
{
    public static class Benchmark
    {
        public static void Measure(Action solve)
        {
            var stopwatch = Stopwatch.StartNew();
            solve();
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
