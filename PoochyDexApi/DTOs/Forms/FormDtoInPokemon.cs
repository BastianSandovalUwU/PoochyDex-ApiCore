namespace PoochyDexApi.DTOs.Forms
{
    public class FormDtoInPokemon
    {
        public List<FormDataDtoInPokemon>? PokemonForms { get; set; }
    }

    public class FormDataDtoInPokemon
    {
        public required string FormName { get; set; }
        public string? urlImage { get; set; }


    }
}
