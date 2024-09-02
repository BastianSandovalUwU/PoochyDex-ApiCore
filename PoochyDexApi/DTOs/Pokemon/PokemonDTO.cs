using PoochyDexApi.DTOs.Generation;
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
        public GenerationDTO Generation { get; set; }
    }
}
