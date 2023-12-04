namespace AdventOfCode2023;

public class Day3
{
    public static int FirstPuzzle(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var n = lines.Length;
        var m = lines[0].Length;
        bool isSymbol(int i, int j) => i >= 0 && i < n && j >= 0 && j < m && (lines[i][j] != '.' && !char.IsDigit(lines[i][j]));

        var ans = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m;)
            {
                var start = j;
                var num = string.Empty;

                while (j < m && char.IsDigit(lines[i][j]))
                    num += lines[i][j++];

                if (!string.IsNullOrEmpty(num))
                {
                    var parsedNum = int.Parse(num);

                    if (isSymbol(i, start - 1) || isSymbol(i, j))
                        ans += parsedNum;
                    else
                    {
                        for (int k = start - 1; k <= j; k++)
                            if (isSymbol(i - 1, k) || isSymbol(i + 1, k))
                            {
                                ans += parsedNum;
                                break;
                            }
                    }
                }
                j++;
            }
        }

        return ans;
    }

    public static int SecondPuzzle(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var n = lines.Length;
        var m = lines[0].Length;

        var goods = new List<List<List<int>>>();
        for (int i = 0; i < n; i++)
        {
            goods.Add([]);
            for (int j = 0; j < m; j++)
            {
                goods[i].Add([]);
            }
        }

        bool IsSymbol(int i, int j, int num)
        {
            if (!(0 <= i && i < n && 0 <= j && j < m))
                return false;

            if (lines[i][j] == '*')
                goods[i][j].Add(num);

            return lines[i][j] != '.' && !char.IsDigit(lines[i][j]);
        }
        var ans = 0;

        for (int i = 0; i < n; i++)
        {
            var start = 0;
            var j = 0;

            while (j < m)
            {
                start = j;
                string num = "";

                while (j < m && char.IsDigit(lines[i][j]))
                {
                    num += lines[i][j];
                    j++;
                }

                if (num == "")
                {
                    j++;
                    continue;
                }

                int parsedNum = int.Parse(num);

                _ = IsSymbol(i, start - 1, parsedNum) || IsSymbol(i, j, parsedNum);

                for (int k = start - 1; k <= j; k++)
                {
                    _ = IsSymbol(i - 1, k, parsedNum) || IsSymbol(i + 1, k, parsedNum);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                List<int> nums = goods[i][j];
                if (lines[i][j] == '*' && nums.Count == 2)
                {
                    ans += nums[0] * nums[1];
                }
            }
        }
        return ans;
    }
}