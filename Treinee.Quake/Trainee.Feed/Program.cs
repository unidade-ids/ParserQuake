using Trainee.Feed.Core;

namespace Trainee.Feed
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserManager parser = new ParserManager();

            parser.GetDeaths();

            foreach (var d in parser.Deaths)
            {
                System.Console.WriteLine($"{d.Killer.Name} matou {d.Killed.Name} by {d.IdArmor}");
            }
        }
    }
}
