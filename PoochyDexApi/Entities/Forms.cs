using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoochyDexApi.Entities
{
    public class Forms
    {
        public required int Id { get; set; }
        public int? PokemonId { get; set; } // Clave foránea
        public Pokemon? Pokemon { get; set; }
        public List<FormData>? PokemonForms { get; set; }

    }

    public class FormData {
        public required int Id {  get; set; }
        public required string FormName {  get; set; }
        public int? HomeSpriteId { get; set; }
        public HomeSprites? HomeSprite { get; set; }

    }
}