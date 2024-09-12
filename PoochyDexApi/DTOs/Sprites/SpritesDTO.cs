using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.Sprites
{
    public class SpritesDTO
    {
        public List<HomeSpritesDTO>? HomeSprites { get; set; }
    }

    public class HomeSpritesDTO
    {
        public string? HomeUrlSprite { get; set; }
        public string? HomeUrlShinySprite { get; set; }
    }
}
