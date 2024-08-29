using AutoMapper;
using PoochyDexApi.DTOs;
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
            CreateMap<Pokemon, PokemonDTO>();
        }
    }
}
