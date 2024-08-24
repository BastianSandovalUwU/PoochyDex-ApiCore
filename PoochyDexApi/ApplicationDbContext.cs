using Microsoft.EntityFrameworkCore;
using PoochyDexApi.Entities;

namespace PoochyDexApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<VideoGames> VideoGames { get; set; }
        public DbSet<ReleaseDate> ReleaseDate { get; set; }
        public DbSet<PokemonList> PokemonList { get; set; }
        public DbSet<Generation> Generation { get; set; }
        public DbSet<Region> Region { get; set; }

    }
}
