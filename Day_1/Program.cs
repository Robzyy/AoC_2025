namespace Day_1;

static class Program
{
    static void Main(string[] args)
    {
        var commands = new List<Tuple<char, int>>();
        
        try
        {
            using var sr = new StreamReader("input.txt");
            // var sr = new StreamReader("test_input.txt");
            
            var line = sr.ReadLine();
            while (line != null)
            {
                var dir = line[0];
                var amount = int.Parse(line[1..]);
                commands.Add(Tuple.Create(dir, amount));
                line = sr.ReadLine();
            }
            //sr.Close();
            Console.WriteLine("Solution 1: {0}", Solve1(commands));
            Console.WriteLine("Solution 2: {0}", Solve2(commands));
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static int Solve1(List<Tuple<char, int>> commands)
    {
        const int start = 50;
        var dial = start;
        var zeroCounter = 0;
        foreach (var command in commands)
        {
            var (dir, amount) = command;
            // Console.WriteLine("Direction " + (dir.Equals('L') ? "Left" : "Right") + " by " + amount);
            dial = (dial + (dir.Equals('L') ? -amount : amount)) % 100;
            // Console.WriteLine(dial);
            if (dial == 0)
            {
                zeroCounter++;
            }
        }
        return zeroCounter;
    }

    private static int Solve2(List<Tuple<char, int>> commands)
    {
        // Not proud of this one but we will roll with it
        
        const int start = 50;
        var dial = start;
        var zeroCounter = 0;
    
        foreach (var command in commands)
        {
            var (dir, amount) = command;
        
            if (dir == 'R')
            {
                for (int i = 1; i <= amount; i++)
                {
                    dial = (dial + 1) % 100;
                    if (dial == 0)
                    {
                        zeroCounter++;
                    }
                }
            }
            else // 'L'
            {
                for (int i = 1; i <= amount; i++)
                {
                    dial = (dial - 1 + 100) % 100;
                    if (dial == 0)
                    {
                        zeroCounter++;
                    }
                }
            }
        }
    
        return zeroCounter;
    }
}