using System.ComponentModel.DataAnnotations;

namespace PoochyDexApi.Entities
{
    public class Pokemon
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ImageURL { get; set; }
        public required int Number { get; set; }
        public required string Type { get; set; }
        public string? Type2 { get; set; }
        public required int generationId { get; set; }
    }
}
