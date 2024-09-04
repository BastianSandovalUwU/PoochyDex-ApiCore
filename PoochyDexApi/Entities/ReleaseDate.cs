namespace PoochyDexApi.Entities
{
    public class ReleaseDate
    {
        public required int Id { get; set; }
        public required string Console { get; set; }
        public required string Date { get; set; }
        public string? Date2 { get; set; }
        public required string Region { get; set; }
        public required int VideoGameId { get; set; } // Propiedad para clave foránea
        public VideoGames? VideoGame { get; set; } // Navegación a VideoGame
    }
}
