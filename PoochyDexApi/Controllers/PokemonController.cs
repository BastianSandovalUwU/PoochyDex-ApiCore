using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PokemonController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Pokemon>>> Get()
        {
            return await context.Pokemon.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "getPokemon")]
        public async Task<ActionResult<Pokemon>> Get(int id)
        {
            var pokemon = await context.Pokemon.FirstOrDefaultAsync(x => x.Number == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult> Post(NewPokemonDTO newPokemonDTO)
        {

            var existePokemon = await context.Pokemon.AnyAsync(x => x.Name == newPokemonDTO.Name);

            if (existePokemon)
            {
                return BadRequest($"ya existe un pokemon con el nombre {newPokemonDTO.Name}");
            }

            var pokemon = mapper.Map<Pokemon>(newPokemonDTO);

            context.Add(pokemon);
            await context.SaveChangesAsync();

            var pokemonDTO = mapper.Map<PokemonDTO>(pokemon);

            return CreatedAtRoute("getPokemon", new { id = pokemon.Id }, pokemonDTO);
        }
    }
}
