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
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Generation> Generation { get; set; }
        public DbSet<Region> Region { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGames>()
           .HasMany(vg => vg.ReleaseDates)
           .WithOne(rd => rd.VideoGame)
           .HasForeignKey(rd => rd.VideoGameId); // Nombre del campo de clave foránea

            // Configuración adicional si es necesaria
        }

    }
}
