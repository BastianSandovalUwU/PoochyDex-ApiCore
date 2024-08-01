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
    }
}
