using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Trainee.Feed.Service;
using Treinee.Feed.Extensions;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Enum;

namespace Trainee.Feed.Core
{
    public class ParserManager
    {
        public Death Death { get; set; }
        public ICollection<Death> Deaths { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
        public Player Killer { get; set; }
        public Player Killed { get; set; }
        public Armor Armor { get; set; }
        public GamePlayer GamePlayer { get; set; }
        public ICollection<GamePlayer> GamePlayers { get; set; }
        public ParserManager()
        {
            this.Deaths      = new List<Death>();
            this.GamePlayers = new List<GamePlayer>();
        }

        public void GetDeaths()
        {

            //TODO: Verificar se existe um player cadastrado by name
            //TODO: Salvar GamePlayer
            //TODO: Salvar mortes


            var service = new ReadFile();
            var result = service.Read().Result;

            ICollection<Death> deaths = new HashSet<Death>();

            using (StringReader reader = new StringReader(result))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    if (line.Contains("InitGame"))
                    {
                        Game = new Game(null);
                    }

                    if (line.Contains("ClientUserinfoChanged"))
                    {
                        var player  = Regex.Match(line, @"n\\(.+?)\\t").Groups[1].ToString().Trim();

                        //TODO Caso não exista usuário, cria um novo usuário
                        this.Player = new Player(player);

                        this.GamePlayer = new GamePlayer(Game, Player);

                        this.GamePlayers.Add(GamePlayer);
                    }

                    if (line.Contains("Kill"))
                    {
                        //TODO Recuperar usuários, caso não exista criar

                        var killed = Regex.Match(line, @"killed (.+?)by").Groups[1].ToString().Trim();


                        var index = line.Substring(line.LastIndexOf(":")).Replace(":", string.Empty).Trim();

                        var killer = index.Before("killed").Trim();

                        var armor = line.Substring(line.LastIndexOf(" by ") + 1).Replace("by", string.Empty).Trim();

                        this.Killer = new Player(killer);
                        this.Killed = new Player(killed);

                        int i = 0;
                        foreach (var a in Enum.GetValues(typeof(DeathEnum)))
                        {
                            if (a.ToString() == armor)
                            {
                                i = (int)a;
                                break;
                            }
                        }


                        this.Deaths.Add(new Death(this.Killer, this.Killed, this.Game, i));

                        //Console.WriteLine($"{killer} matou {killed} com {armor} ");
                    }

                            
                }
            }
        }
    }
}
