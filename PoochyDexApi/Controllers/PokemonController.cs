using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Pokemon;
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
        public async Task<ActionResult<List<PokemonDTO>>> Get()
        {
            var pokemon = await context.Pokemon.Include(x => x.Generation).ToListAsync();

            var pokemonDTO = mapper.Map<PokemonDTO>(pokemon);

            return Ok(pokemonDTO);
        }

        [HttpGet("{id:int}", Name = "getPokemon")]
        public async Task<ActionResult<PokemonDTO>> Get(int id)
        {
            var pokemon = await context.Pokemon
                .Include(x => x.Generation)
                .FirstOrDefaultAsync(x => x.Number == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemonDTO = mapper.Map<PokemonDTO>(pokemon);

            return Ok(pokemonDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post(NewPokemonDTO newPokemonDTO)
        {

            var existePokemon = await context.Pokemon.AnyAsync(x => x.Number == newPokemonDTO.Number);

            if (existePokemon)
            {
                return BadRequest($"ya existe un pokemon con el nombre {newPokemonDTO.Name}");
            }

            var pokemon = mapper.Map<Pokemon>(newPokemonDTO);

            context.Add(pokemon);
            await context.SaveChangesAsync();

            var pokemonDTO = mapper.Map<NewPokemonDTO>(pokemon);

            return CreatedAtRoute("getPokemon", new { id = pokemon.Id }, pokemonDTO);
        }
    }
}
