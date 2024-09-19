using AutoMapper;
using PoochyDexApi.DTOs.Forms;
using PoochyDexApi.DTOs.Generation;
using PoochyDexApi.DTOs.Pokemon;
using PoochyDexApi.DTOs.Region;
using PoochyDexApi.DTOs.ReleaseDate;
using PoochyDexApi.DTOs.Sprites;
using PoochyDexApi.DTOs.VideoGame;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NewVideoGameDTO, VideoGames>();
            CreateMap<VideoGames, VideoGameDTO>()
                        .ForMember(dest => dest.ReleaseDates, opt => opt.MapFrom(src => src.ReleaseDates));
            CreateMap<NewVideoGameDTO, VideoGames>()
                        .ForMember(dest => dest.ReleaseDates, opt => opt.MapFrom(src => src.ReleaseDates));
            CreateMap<NewPokemonDTO, Pokemon>();
            CreateMap<Pokemon, PokemonDTO>()
                       .ForMember(dest => dest.Forms, opt => opt.MapFrom(src => src.Forms))
                       .ForMember(dest => dest.Generation, opt => opt.MapFrom(src => src.Generation));
            CreateMap<Generation, GenerationDTO>()
                        .ForMember(dest => dest.VideoGames, opt => opt.MapFrom(src => src.VideoGames
                            .Select(vg => new VideoGameInGenerationDTO
                            {
                                Games = vg.Games,               // Mapeo de la lista de juegos
                                Platforms = vg.Platforms         // Mapeo de la lista de plataformas
                            })
                            .ToList()));
            CreateMap<Generation, GenerationWithGamesDTO>()
            .ForMember(dest => dest.Games, opt => opt.MapFrom(src =>
                src.VideoGames
                    .SelectMany(vg => vg.Games)
                    .Distinct()
                    .ToList()))
            .ForMember(dest => dest.Platforms, opt => opt.MapFrom(src =>
                src.VideoGames
                    .SelectMany(vg => vg.Platforms)
                    .Distinct()
                    .ToList()));
            CreateMap<NewGenerationDTO, Generation>();
            CreateMap<NewRegionDTO, Region>();
            CreateMap<ReleaseDateDTO, ReleaseDate>();
            CreateMap<ReleaseDate, ReleaseDateDTO>();
            CreateMap<RegionDTO, Region>();
            CreateMap<Region, RegionDTO>();

            CreateMap<NewFormDTOwithPokemonId, Forms>()
                .ForMember(dest => dest.PokemonForms, opt => opt.MapFrom(src => src.PokemonForms));

            CreateMap<FormDataDTO, FormData>();
            CreateMap<Forms, FormsDTO>()
                        .ForMember(dest => dest.PokemonId, opt => opt.MapFrom(src => src.PokemonId)) // Mapea PokemonId
                        .ForMember(dest => dest.PokemonForms, opt => opt.MapFrom(src => src.PokemonForms));

            CreateMap<FormData, FormDataDTO>();

            // Mapeo para Forms y su DTO
            CreateMap<Forms, FormDtoInPokemon>()
                .ForMember(dest => dest.PokemonForms, opt => opt.MapFrom(src => src.PokemonForms));

            // Mapeo para FormData y su DTO
            CreateMap<FormData, FormDataDtoInPokemon>();
            CreateMap<HomeSpritesDTO, HomeSprites>();
            CreateMap<HomeSprites, HomeSpritesDTO>();



        }
    }
}
