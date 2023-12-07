namespace AdventOfCode2023;

public static class Day6
{
    public static int FirstPuzzle(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var times = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();
        var dists = lines[1].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();

        var product = times.Zip(dists, (t, d) => Enumerable.Range(0, t).Count(i => (t - i) * i > d)).Aggregate(1, (acc, x) => acc * x);

        return product;
    }

    public static int SecondPuzzle(string filePath)
    {
        var lines = File.ReadAllText(filePath).Trim().Split('\n'); ;

        var t = long.Parse(string.Join("", lines[0].Split().Skip(1)));
        var d = long.Parse(string.Join("", lines[1].Split().Skip(1)));

        var result = Ways(t, d);

        return result;
    }

    private static int Ways(long t, long d)
    {
        var count = 0;
        for (int i = 0; i < t; i++)
        {
            if ((t - i) * i > d)
            {
                count++;
            }
        }

        return count;
    }
}