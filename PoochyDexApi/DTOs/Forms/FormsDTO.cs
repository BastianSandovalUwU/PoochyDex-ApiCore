using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.Forms
{
    public class FormsDTO
    {
        public int Id { get; set; }
        public int? PokemonId { get; set; }
        public List<FormDataDTO>? PokemonForms { get; set; }
    }

    public class FormDataDTO
    {
        public int Id { get; set; }
        public required string FormName { get; set; }

    }
}
