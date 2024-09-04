using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.ReleaseDate
{
    public class ReleaseDateDTO
    {
        public required string Console { get; set; }
        public required string Date { get; set; }
        public string? Date2 { get; set; }
        public required string Region { get; set; }
        public int VideoGameId { get; set; } // Propiedad para clave foránea
    }
}
