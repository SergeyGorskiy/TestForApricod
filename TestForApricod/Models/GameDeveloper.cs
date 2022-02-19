using System.Collections.Generic;

namespace TestForApricod.Models
{
    public class GameDeveloper
    {
        public int GameDeveloperId { get; set; }

        public string GameDeveloperName { get; set; }

        public List<Game> Games { get; set; }
    }
}