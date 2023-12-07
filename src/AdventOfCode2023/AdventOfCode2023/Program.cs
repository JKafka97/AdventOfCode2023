namespace AdventOfCode2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Day 1 first puzzle: {Day1.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day1.txt"))}");
        Console.WriteLine($"Day 1 second puzzle: {Day1.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day1.txt"))}");
        Console.WriteLine($"Day 2 first puzzle: {Day2.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day2.txt"))}");
        Console.WriteLine($"Day 2 second puzzle: {Day2.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day2.txt"))}");
        Console.WriteLine($"Day 3 first puzzle: {Day3.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day3.txt"))}");
        Console.WriteLine($"Day 3 second puzzle: {Day3.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day3.txt"))}");
        Console.WriteLine($"Day 4 first puzzle: {Day4.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day4.txt"))}");
        Console.WriteLine($"Day 4 second puzzle: {Day4.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day4.txt"))}");
        Console.WriteLine($"Day 5 first puzzle: {Day5.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day5.txt"))}");
        Console.WriteLine($"Day 5 second puzzle: {Day5.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day5.txt"))}");
        Console.WriteLine($"Day 6 first puzzle: {Day6.FirstPuzzle(Path.Combine(PathConstants.RootPath, "Day6.txt"))}");
        Console.WriteLine($"Day 6 second puzzle: {Day6.SecondPuzzle(Path.Combine(PathConstants.RootPath, "Day6.txt"))}");
    }
}