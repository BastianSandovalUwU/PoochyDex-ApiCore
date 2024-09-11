using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.Sprites
{
    public class SpritesDTO
    {
        public List<HomeSpritesDTO>? HomeSprites { get; set; }
    }

    public class HomeSpritesDTO
    {
        public string? HomeUrlSpritre { get; set; }
        public string? HomeUrlShinySpritre { get; set; }
    }
}
