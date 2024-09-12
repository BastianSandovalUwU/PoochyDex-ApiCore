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
        public DbSet<Sprites> Sprites { get; set; }
        public DbSet<Forms> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VideoGames>()
           .HasMany(vg => vg.ReleaseDates)
           .WithOne(rd => rd.VideoGame)
           .HasForeignKey(rd => rd.VideoGameId); // Nombre del campo de clave foránea

            modelBuilder.Entity<Forms>()
                .HasKey(f => f.Id); // Definir Id como clave primaria
        
            modelBuilder.Entity<Forms>()
                .HasOne(f => f.Pokemon)
                .WithMany(p => p.Forms)
                .HasForeignKey(f => f.PokemonId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Sprites>()
                .HasOne(s => s.Pokemon)
                .WithMany(p => p.Sprites) // Asegúrate de que 'Sprites' es una lista
                .HasForeignKey(s => s.PokemonId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Forms>()
            .HasOne(f => f.Pokemon)
            .WithMany(p => p.Forms)
            .HasForeignKey(f => f.PokemonId)
            .OnDelete(DeleteBehavior.Restrict); // Ajusta el comportamiento de eliminación si es necesario

            base.OnModelCreating(modelBuilder);
            
        }

    }
}
