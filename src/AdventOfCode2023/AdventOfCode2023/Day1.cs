namespace AdventOfCode2023;

public static class Day1
{
    public static int FirstPuzzle(string filePath)
    {
        var sum = 0;
        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var numbers = new List<string>();
                foreach (var line2 in line)
                {
                    if (char.IsDigit(line2))
                    {
                        numbers.Add(line2.ToString());
                    }
                }
                var numberinos = numbers.FirstOrDefault() + numbers.LastOrDefault();
                sum += int.Parse(numberinos);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return sum;
    }

    public static int SecondPuzzle(string filePath)
    {
        var sum = 0;
        var numbersDict = new Dictionary<string, int>() {
        {"one", 1 },
        {"two",2 },
        {"three",3 },
        {"four",4 },
        {"five",5 },
        {"six",6},
        {"seven",7 },
        {"eight",8 },
        {"nine",9 },
        {"1",1 },
        {"2",2 },
        {"3",3 },
        {"4",4 },
        {"5",5 },
        {"6",6 },
        {"7",7 },
        {"8",8 },
        {"9",9 },
    };

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var numbers = new Dictionary<int, string>();
                foreach (var key in numbersDict.Keys)
                {
                    numbers[line.IndexOf(key)] = key;
                    numbers[line.LastIndexOf(key)] = key;
                }
                var min = numbers[numbers.Keys.Where(x => x >= 0).Min()];
                var max = numbers[numbers.Keys.Max()];
                sum += int.Parse(numbersDict[min].ToString() + numbersDict[max].ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return sum;
    }
}