using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForApricod.EF;
using TestForApricod.Models;

namespace TestForApricod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext _context;

        public GameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Game> GetAllGames()
        {
            IEnumerable<Game> games = _context.Games
                .Include(p => p.GameGenres)
                .Include(g => g.GameDeveloper);

            foreach (Game g in games)
            {
                foreach (GameGenre gg in g.GameGenres)
                {
                    gg.Games = null;
                }
                g.GameDeveloper.Games = null;
            }

            return games;
        }

        [HttpGet("{id}/getGameById")]
        public Game GetGameById(int id)
        {
            Game game = _context.Games
                .Include(g => g.GameGenres)
                .Include(g => g.GameDeveloper)
                .FirstOrDefault(g => g.GameId == id);

            foreach (GameGenre gg in game.GameGenres)
            {
                gg.Games = null;
            }
            game.GameDeveloper.Games = null;

            return game;
        }

        [HttpGet("{genreName}/getGamesByGenre")]
        public IEnumerable<Game> GetGamesByGenre(string genreName)
        {
            GameGenre gameGenre = _context.GameGenres.FirstOrDefault(g => g.GameGenreName == genreName);

            IEnumerable<Game> games = _context.Games
                .Where(g => g.GameGenres.Contains(gameGenre))            
                .Include(p => p.GameGenres)
                .Include(g => g.GameDeveloper);

            foreach (Game game in games)
            {
                foreach (GameGenre gg in game.GameGenres)
                {
                    gg.Games = null;
                }
                game.GameDeveloper.Games = null;
            }

            return games;
        }

        [HttpPost]
        public void CreateGame(Game game)
        {
            foreach (GameGenre gg in game.GameGenres)
            {
                gg.Games = null;
            }
            game.GameDeveloper.Games = null;

            _context.Games.Add(game);
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdateGame(Game game)
        {
            foreach (GameGenre gg in game.GameGenres)
            {
                gg.Games = null;
            }
            game.GameDeveloper.Games = null;

            _context.Games.Update(game);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteGame(int id)
        {
            _context.Games.Remove(new Game { GameId = id });
            _context.SaveChanges();
        }
    }
}
