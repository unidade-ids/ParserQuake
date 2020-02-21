using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Trainee.Feed.Service;
using Treinee.Feed.Extensions;
using Treinee.Quake.Domain.Entity;

namespace Trainee.Feed.Core
{
    public class ParserManager
    {
        public ParserManager()
        {
        }

        public void GetDeaths()
        {
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

                    }

                    if (line.Contains("ClientUserinfoChanged"))
                    {
                        var changed = Regex.Match(line, @"n\\(.+?)\\t").Groups[1];

                        Console.WriteLine($"{changed}");
                    }

                    if (line.Contains("Kill"))
                    {
                        var killed = Regex.Match(line, @"killed (.+?)by").Groups[1];


                        var index = line.Substring(line.LastIndexOf(":")).Replace(":", string.Empty).Trim();

                        var killer = index.Before("killed").Trim();

                        var armor = line.Substring(line.LastIndexOf(" by ") + 1).Replace("by", string.Empty).Trim();


                        //Console.WriteLine($"{killer} matou {killed} com {armor} ");
                    }

                            
                }
            }
        }
    }
}
