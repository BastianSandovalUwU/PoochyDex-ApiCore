using PoochyDexApi.DTOs.VideoGame;

namespace PoochyDexApi.DTOs.Generation
{
    public class GenerationDTO
    {
        public required string Name { get; set; }
        public List<VideoGameInGenerationDTO>? VideoGames { get; set; }

    }
}
