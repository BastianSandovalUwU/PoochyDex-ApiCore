namespace PoochyDexApi.Entities
{
    public class Sprites
    {
        public required int Id { get; set; }  
        public int? PokemonId { get; set; } // Clave foránea
        public Pokemon? Pokemon { get; set; }
        public List<HomeSprites>? HomeSprites { get; set; }
    }

}