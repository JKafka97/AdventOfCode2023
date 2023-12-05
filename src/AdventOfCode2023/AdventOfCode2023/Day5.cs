using System.IO;

namespace AdventOfCode2023;

public static class Day5
{
    public static long FirstPuzzle(string filePath)
    {
        var lines = File.ReadAllLines(filePath).Select(line => line.Trim()).ToArray();
        var seeds = lines[0].Split(' ').Skip(1).Select(long.Parse).ToList();
        var maps = new List<List<(long dstStart, long srcStart, long rangeLen)>>();

        for (int i = 2; i < lines.Length;)
        {
            maps.Add([]);

            i++;
            while (i < lines.Length && lines[i] != "")
            {
                var parts = lines[i].Split().Select(long.Parse).ToArray();
                var dstStart = parts[0];
                var srcStart = parts[1];
                var rangeLen = parts[2];
                maps.Last().Add((dstStart, srcStart, rangeLen));
                i++;
            }

            i++;
        }

        var locs = seeds.Select(seed => FindLoc(seed, maps)).ToList();
        return locs.Min();
    }

    static long FindLoc(long seed, List<List<(long dstStart, long srcStart, long rangeLen)>> maps)
    {
        var curNum = seed;

        foreach (var m in maps)
        {
            foreach (var (dstStart, srcStart, rangeLen) in m)
            {
                if (srcStart <= curNum && curNum < srcStart + rangeLen)
                {
                    curNum = dstStart + (curNum - srcStart);
                    break;
                }
            }
        }

        return curNum;
    }


    public static long SecondPuzzle(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        var rawSeeds = lines[0].Split(' ').Skip(1).Select(long.Parse).ToList();
        var seeds = Enumerable.Range(0, rawSeeds.Count / 2)
            .Select(i => (rawSeeds[i * 2], rawSeeds[i * 2 + 1]))
            .ToList();

        var maps = new List<List<(long, long, long)>>();

        int i = 2;
        while (i < lines.Length)
        {
            string[] categories = lines[i].Split(' ')[0].Split('-');
            maps.Add([]);

            i += 1;
            while (i < lines.Length && lines[i] != "")
            {
                var values = lines[i].Split().Select(long.Parse).ToArray();
                maps[^1].Add((values[0], values[1], values[2]));
                i += 1;
            }

            maps[^1].Sort((x, y) => x.Item2.CompareTo(y.Item2));

            i += 1;
        }

        foreach (var m in maps)
        {
            for (int j = 0; j < m.Count - 1; j++)
            {
                if (!(m[j].Item2 + m[j].Item3 <= m[j + 1].Item2))
                {
                    Console.WriteLine($"{m[j]} {m[j + 1]}");
                }
            }
        }

        var locs = new List<(long, long)>();
        long ans = 1 << 60;

        foreach (var (start, R) in seeds)
        {
            var curIntervals = new List<(long, long)> { (start, start + R - 1) };
            var newIntervals = new List<(long, long)>();

            foreach (var m in maps)
            {
                foreach (var (lo, hi) in curIntervals)
                {
                    newIntervals.AddRange(Remap(lo, hi, m));
                }

                (curIntervals, newIntervals) = (newIntervals, new List<(long, long)>());
            }

            foreach (var (lo, hi) in curIntervals)
            {
                ans = Math.Min(ans, lo);
            }
        }

        return ans;
    }

    static IEnumerable<(long, long)> Remap(long lo, long hi, List<(long, long, long)> m)
    {
        var ans = new List<(long, long, long)>();

        foreach (var (dst, src, R) in m)
        {
            var end = src + R - 1;
            var D = dst - src;

            if (!(end < lo || src > hi))
            {
                ans.Add((Math.Max(src, lo), Math.Min(end, hi), D));
            }
        }

        foreach (var (l, r, D) in ans)
        {
            yield return (l + D, r + D);

            if (ans.IndexOf((l, r, D)) < ans.Count - 1 && ans[ans.IndexOf((l, r, D)) + 1].Item1 > r + 1)
            {
                yield return (r + 1, ans[ans.IndexOf((l, r, D)) + 1].Item1 - 1);
            }
        }

        if (ans.Count == 0)
        {
            yield return (lo, hi);
            yield break;
        }

        if (ans[0].Item1 != lo)
        {
            yield return (lo, ans[0].Item1 - 1);
        }
        if (ans[^1].Item2 != hi)
        {
            yield return (ans[^1].Item2 + 1, hi);
        }
    }


}