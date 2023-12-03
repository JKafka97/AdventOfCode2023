namespace AdventOfCode2023;

public static class Day2
{
    public static int FirstPuzzle(string filePath)
    {
        var gameList = new List<int>();
        var criteria = new Dictionary<string, int>()
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 }
            };

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var game = line[5..].Split(":");
                var gameId = game[0];
                var games = game[1].Split(";");

                var legit = true;
                foreach (var item in games)
                {
                    var gameCount = new Dictionary<string, int>()
                        {
                               {"red", 0 },
                            {"green", 0 },
                            {"blue", 0}
                        };
                    var colors = item[1..].Split(", ");
                    foreach (var exp in colors)
                    {
                        var number = exp.Split(" ")[0];
                        var color = exp.Split(" ")[1];
                        gameCount[color] += Int32.Parse(number);
                    }
                    if (gameCount["red"] > criteria["red"] || gameCount["green"] > criteria["green"] || gameCount["blue"] > criteria["blue"])
                    {
                        legit = false;
                    }
                }
                if (legit)
                {
                    gameList.Add(Int32.Parse(gameId));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return gameList.Sum();
    }

    public static int SecondPuzzle(string filePath)
    {
        var gameList = new List<int>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var game = line[5..].Split(":");
                var gameId = game[0];
                var games = game[1].Split(";");
                var gamemax = new Dictionary<string, int>()
                        {
                               {"red", 0 },
                            {"green", 0 },
                            {"blue", 0}
                        };
                foreach (var item in games)
                {
                    var gameCount = new Dictionary<string, int>()
                        {
                               {"red", 0 },
                            {"green", 0 },
                            {"blue", 0}
                        };
                    var colors = item[1..].Split(", ");
                    foreach (var exp in colors)
                    {
                        var number = exp.Split(" ")[0];
                        var color = exp.Split(" ")[1];
                        gameCount[color] += Int32.Parse(number);
                    }
                    if (gameCount["red"] > gamemax["red"])
                    {
                        gamemax["red"] = gameCount["red"];
                    }
                    if (gameCount["green"] > gamemax["green"])
                    {
                        gamemax["green"] = gameCount["green"];
                    }
                    if (gameCount["blue"] > gamemax["blue"])
                    {
                        gamemax["blue"] = gameCount["blue"];
                    }
                }
                gameList.Add(gamemax["blue"] * gamemax["green"] * gamemax["red"]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return gameList.Sum();
    }
}