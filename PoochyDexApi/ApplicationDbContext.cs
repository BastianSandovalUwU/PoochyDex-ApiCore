using Microsoft.EntityFrameworkCore;
using PoochyDexApi.Entities;

namespace PoochyDexApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<PokemonList> PokemonList { get; set; }
        public DbSet<Games> Games{ get; set; }
        public DbSet<Generation> Generation{ get; set; }
        public DbSet<Region> Region{ get; set; }

    }
}
