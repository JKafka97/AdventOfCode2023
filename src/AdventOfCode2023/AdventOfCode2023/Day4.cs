using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public static class Day4
    {
        public static int FirstPuzzle(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Sum(line =>
                       {
                           var data = line.Split(':')[1].Split("|");
                           var winningNumbers = data[0].Split(" ").Where(x => x != "");
                           var myNumbers = data[1].Split(" ").Where(x => x != "");
                           var lineScore = myNumbers.Count(number => winningNumbers.Contains(number));
                           return lineScore > 0 ? (int)Math.Pow(2, lineScore - 1) : 0;
                       });
        }

        public static int SecondPuzzle(string filePath)
        {
            var lines = File.ReadAllLines(filePath)
                            .Select(line => line.Trim())
                            .ToArray();

            var n = lines.Length;
            var copies = Enumerable.Range(0, n)
                                   .Select(_ => Enumerable.Empty<int>().ToArray())
                                   .ToArray();

            Enumerable.Range(0, n).ToList().ForEach(i =>
            {
                var parts = Regex.Split(lines[i], @"\s+");
                var idx = Array.IndexOf(parts, "|");
                var winning = parts.Skip(2).Take(idx - 2).Select(int.Parse);
                var ours = parts.Skip(idx + 1).Select(int.Parse);
                var score = ours.Count(num => winning.Contains(num));

                Enumerable.Range(i + 1, Math.Min(score, n - i - 1)).ToList().ForEach(j =>
                    copies[i] = [.. copies[i], j]
                );
            });

            var scoreArray = Enumerable.Repeat(1, n).ToArray();

            Enumerable.Range(0, n).Reverse().ToList().ForEach(i =>
                copies[i].ToList().ForEach(j => scoreArray[i] += scoreArray[j])
            );

            return scoreArray.Sum();
        }
    }
}