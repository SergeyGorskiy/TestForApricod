using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestForApricod.Models;

namespace TestForApricod.EF
{
    public class SeedData
    {
        public static void SeedDataBase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Games.Any() && !context.GameGenres.Any() && !context.GameDevelopers.Any())
            {
                GameGenre gg1 = new GameGenre { GameGenreName = "arcade" };
                GameGenre gg2 = new GameGenre { GameGenreName = "simulator" };
                GameGenre gg3 = new GameGenre { GameGenreName = "RPG" };
                GameGenre gg4 = new GameGenre { GameGenreName = "action" };
                GameGenre gg5 = new GameGenre { GameGenreName = "sport" };

                context.GameGenres.AddRange(gg1, gg2, gg3, gg4, gg5);
                context.SaveChanges();

                GameDeveloper gd1 = new GameDeveloper { GameDeveloperName = "Microsoft Studios" };
                GameDeveloper gd2 = new GameDeveloper { GameDeveloperName = "Electronic Arts" };
                GameDeveloper gd3 = new GameDeveloper { GameDeveloperName = "Namco Bandai Games" };
                GameDeveloper gd4 = new GameDeveloper { GameDeveloperName = "Konami" };

                context.GameDevelopers.AddRange(gd1, gd2, gd3, gd4);
                context.SaveChanges();

                context.Games.AddRange(new Game
                {
                    GameName = "Forza Horizon",
                    GameGenres = new List<GameGenre> { gg1, gg2 },
                    GameDeveloper = gd1
                },
                new Game
                {
                    GameName = "Medal of Honor",
                    GameGenres = new List<GameGenre> { gg3, gg4 },
                    GameDeveloper = gd2
                },
                new Game
                {
                    GameName = "Witcher",
                    GameGenres = new List<GameGenre> { gg3 },
                    GameDeveloper = gd3
                },
                new Game
                {
                    GameName = "Castlevania",
                    GameGenres = new List<GameGenre> { gg4 },
                    GameDeveloper = gd4
                },
                new Game
                {
                    GameName = "Need for Speed",
                    GameGenres = new List<GameGenre> { gg1, gg2, gg5 },
                    GameDeveloper = gd2
                });

                context.SaveChanges();
            }
        }
    }
}