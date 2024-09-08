namespace PoochyDexApi.Entities
{
    public class Sprites
    {
        public required int Id { get; set; }  
        public int? PokemonId { get; set; } // Clave foránea
        public Pokemon? Pokemon { get; set; }
        public List<HomeSprites>? HomeSprites { get; set; }
    }

    public class HomeSprites 
    {
        public required int Id { get; set; }
        public string? HomeUrlSpritre { get; set; }
        public string? HomeUrlShinySpritre { get; set; }
    }
}