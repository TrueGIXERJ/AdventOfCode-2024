namespace AdventOfCode2024
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1 Solutions:");
            Benchmark.Measure(Day1.Solve);
            Console.WriteLine("Day 2 Solutions:");
            Benchmark.Measure(Day2.Solve);
            Console.WriteLine("Day 3 Solutions:");
            Benchmark.Measure(Day3.Solve);
            Console.WriteLine("Day 4 Solutions:");
            Benchmark.Measure(Day4.Solve);
        }
    }
}
