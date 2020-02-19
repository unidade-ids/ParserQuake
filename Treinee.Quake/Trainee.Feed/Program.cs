using Trainee.Feed.Core;

namespace Trainee.Feed
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserManager parser = new ParserManager();

            parser.GetDeaths();
        }
    }
}
