namespace AdventOfCode2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Day 1 first puzzle: {Day1.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day1.txt"))}");
        Console.WriteLine($"Day 1 second puzzle: {Day1.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day1.txt"))}");
        Console.WriteLine($"Day 2 first puzzle: {Day2.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day2.txt"))}");
        Console.WriteLine($"Day 2 second puzzle: {Day2.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day2.txt"))}");
    }
}