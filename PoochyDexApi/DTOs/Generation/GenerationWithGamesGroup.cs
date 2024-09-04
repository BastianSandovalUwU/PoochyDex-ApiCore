using PoochyDexApi.DTOs.Generation;

namespace PoochyDexApi.DTOs.Generation
{
    public class GenerationWithGamesDTO
    {
        public required string Name { get; set; }
        public List<string> Games { get; set; } = new List<string>();
        public List<string> Platforms{ get; set; } = new List<string>();


    }

}
