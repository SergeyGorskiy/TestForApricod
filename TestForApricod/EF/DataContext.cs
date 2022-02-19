using Microsoft.EntityFrameworkCore;
using TestForApricod.Models;

namespace TestForApricod.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameGenre> GameGenres { get; set; }

        public DbSet<GameDeveloper> GameDevelopers { get; set; }
    }
}