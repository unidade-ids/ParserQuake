using SimpleInjector.Lifestyles;
using Trainee.Feed.Config;
using Trainee.Feed.Core;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Trainee.Feed
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory.Start();

            ParserManager parser = new ParserManager();

            using (ThreadScopedLifestyle.BeginScope(Factory.Container))
            {
                var unit                 = Factory.Container.GetInstance<IUnitOfWork>();
                var gameRepository       = Factory.Container.GetInstance<IRepositoryBase<Game>>();
                var armorRepository      = Factory.Container.GetInstance<IRepositoryBase<Armor>>();
                var deathRepository      = Factory.Container.GetInstance<IRepositoryBase<Death>>();
                var playerRepository     = Factory.Container.GetInstance<IRepositorioPlayer>();
                var gamePlayerRepository = Factory.Container.GetInstance<IRepositorioGamePlayer>();

                try
                {
                    System.Console.WriteLine("Informações sendo salvas...");
                    parser.GetDeaths(gameRepository, playerRepository, gamePlayerRepository, armorRepository, deathRepository, unit);
                }
                catch (System.Exception ex)
                {
                    unit.RollBack();
                    System.Console.WriteLine($"Erro: {ex.Message}");
                }
            }

        }
    }
}
