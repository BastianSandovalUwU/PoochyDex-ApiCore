
namespace PoochyDexApi.DTOs.Forms
{
    public class NewFormDTO
    {
        public List<FormDataDTO>? PokemonForms { get; set; }
    }

    public class NewFormDTOwithPokemonId
    {
        public int PokemonId { get; set; }
        public List<FormDataDTO>? PokemonForms { get; set; }
    }
}
