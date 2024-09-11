using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.Forms
{
    public class FormsDTO
    {
        public List<FormDataDTO>? PokemonForms { get; set; }
    }

    public class FormDataDTO
    {
        public required string FormName { get; set; }

    }
}
