using PoochyDexApi.DTOs.Forms;
using PoochyDexApi.DTOs.Generation;
using PoochyDexApi.DTOs.Sprites;
using PoochyDexApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace PoochyDexApi.DTOs.Pokemon
{
    public class PokemonDTO
    {
        public required string Name { get; set; }
        public required string ImageURL { get; set; }
        public required int Number { get; set; }
        public required string Type { get; set; }
        public string? Type2 { get; set; }
        public required int generationId { get; set; }
        public required GenerationWithGamesDTO Generation { get; set; }
        public bool? AltForms { get; set; }
        public List<SpritesDTO>? Sprites { get; set; }
        public List<FormsDTO>? Forms { get; set; }
    }
}
