namespace Day_1;

static class Program
{
    static void Main(string[] args)
    {
        var commands = new List<Tuple<char, int>>();
        
        try
        {
            var sr = new StreamReader("input.txt");
            // var sr = new StreamReader("test_input.txt");
            
            var line = sr.ReadLine();
            while (line != null)
            {
                var dir = line[0];
                var amount = int.Parse(line[1..]);
                commands.Add(Tuple.Create(dir, amount));
                line = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine(Solve(commands));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private static int Solve(List<Tuple<char, int>> commands)
    {
        const int start = 50;
        var dial = start;
        var zeroCounter = 0;
        foreach (var command in commands)
        {
            (char dir,  int amount) = command;
            // Console.WriteLine("Direction " + (dir.Equals('L') ? "Left" : "Right") + " by " + amount);
            dial = (dial + (dir.Equals('L') ? -amount : amount)) % 100;
            Console.WriteLine(dial);
            if (dial == 0)
            {
                zeroCounter++;
            }
        }
        return zeroCounter;
    }
}