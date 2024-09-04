using PoochyDexApi.DTOs.Generation;

namespace PoochyDexApi.DTOs.Region
{
    public class RegionDTO
    {
        public required string RegionName { get; set; }
        public required int GenerationId { get; set; }
        public GenerationWithGamesDTO? Generation { get; set; }
    }
}
