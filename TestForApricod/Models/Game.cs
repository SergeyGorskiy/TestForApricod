using System.Collections.Generic;

namespace TestForApricod.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public string GameName { get; set; }

        public List<GameGenre> GameGenres { get; set; }

        public GameDeveloper GameDeveloper { get; set; }
    }
}