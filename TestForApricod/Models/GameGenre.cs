using System.Collections.Generic;

namespace TestForApricod.Models
{
    public class GameGenre
    {
        public int GameGenreId { get; set; }

        public string GameGenreName { get; set; }

        public List<Game> Games { get; set; }
    }
}