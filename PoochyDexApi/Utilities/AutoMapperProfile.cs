using AutoMapper;
using PoochyDexApi.DTOs.Generation;
using PoochyDexApi.DTOs.Pokemon;
using PoochyDexApi.DTOs.Region;
using PoochyDexApi.DTOs.VideoGame;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NewVideoGameDTO, VideoGames>();
            CreateMap<VideoGames, VideoGameDTO>();
            CreateMap<NewPokemonDTO, Pokemon>();
            CreateMap<Pokemon, PokemonDTO>()
                .ForMember(dest => dest.Generation, opt => opt.MapFrom(src => src.Generation));
            CreateMap<Generation, GenerationDTO>();
            CreateMap<NewGenerationDTO, Generation>();
            CreateMap<NewRegionDTO, Region>();

        }
    }
}
