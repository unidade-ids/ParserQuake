using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Trainee.Feed.Service;
using Treinee.Quake.Domain.Core;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Trainee.Feed.Core
{
    public class ParserManager
    {
        public ManagerGame ManagerGame { get; set; }
        public ManagerPlayer ManagerPlayer { get; set; }
        public ManagerGamePlayer ManagerGamePlayer { get; set; }
        public ManagerDeath ManagerDeath { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }

        public ParserManager()
        {
        }

        public void GetDeaths(IRepositoryBase<Game> gameRepository, IRepositorioPlayer playerRepository,
                              IRepositoryBase<GamePlayer> gamePlayerRepository, IRepositoryBase<Armor> armorRepository,
                              IRepositoryBase<Death> deathRepository, IUnitOfWork unit)
        {
            var service = new ReadFile();
            var result  = service.Read().Result;

            using (StringReader reader = new StringReader(result))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("InitGame"))
                    {
                        this.ManagerGame = new ManagerGame(line, gameRepository, unit);
                        this.Game = this.ManagerGame.Save().GetAwaiter().GetResult();
                    }

                    if (line.Contains("ClientUserinfoChanged"))
                    {
                        this.ManagerPlayer = new ManagerPlayer(line, playerRepository, unit);
                        this.Player        = this.ManagerPlayer.Save().GetAwaiter().GetResult();

                        this.ManagerGamePlayer = new ManagerGamePlayer(Game, Player, gamePlayerRepository, unit);
                        ManagerGamePlayer.Save().GetAwaiter().GetResult();
                    }

                    if (line.Contains("Kill"))
                    {
                        ManagerDeath = new ManagerDeath(line, gameRepository, gamePlayerRepository, playerRepository, armorRepository, deathRepository, unit, Game);
                        ManagerDeath.Save().GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}
