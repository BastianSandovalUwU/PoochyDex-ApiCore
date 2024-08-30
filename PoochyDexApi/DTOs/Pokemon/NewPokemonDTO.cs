using System.ComponentModel.DataAnnotations;

namespace PoochyDexApi.DTOs.Pokemon
{
    public class NewPokemonDTO
    {
        public required string Name { get; set; }
        public string? ImageURL { get; set; }
        public required int Number { get; set; }
        public string? Type { get; set; }
        public string? Type2 { get; set; }
        public required int generationId { get; set; }

    }
}
