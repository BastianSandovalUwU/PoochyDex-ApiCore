using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Pokemon;
using PoochyDexApi.DTOs.VideoGame;
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
            var pokemon = await context.Pokemon
                .Include(x => x.Generation)
                .ThenInclude(g => g.VideoGames) // Incluir los videojuegos relacionados
                .ToListAsync();

            var pokemonDTOs = mapper.Map<List<PokemonDTO>>(pokemon);

            return Ok(pokemonDTOs);
        }

        [HttpGet("{id:int}", Name = "getPokemon")]
        public async Task<ActionResult<PokemonDTO>> Get(int id)
        {
            var pokemon = await context.Pokemon
                .Include(x => x.Generation)
                    .ThenInclude(g => g.VideoGames) // Incluir los videojuegos relacionados
                .Include(x => x.Forms)
                    .ThenInclude(f => f.PokemonForms)
                .FirstOrDefaultAsync(x => x.Number == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemonDTO = mapper.Map<PokemonDTO>(pokemon);

            var groupedPokemonForms = pokemonDTO.Forms
                                        .SelectMany(f => f.PokemonForms)
                                        .ToList();

            var result = new
            {
                pokemonDTO,
                Forms = groupedPokemonForms // Aquí tienes todos los 'pokemonForms' en un solo array
            };

            return Ok(result);
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

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<PokemonDTO>> Put(int id, NewPokemonDTO newPokemonDTO)
        {
            var existingPokemon = await context.Pokemon
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingPokemon == null)
            {
                return NotFound("No se encuentra un Pokémon con este ID.");
            }

            existingPokemon.Name = newPokemonDTO.Name;
            existingPokemon.ImageURL = newPokemonDTO.ImageURL;
            existingPokemon.Type = newPokemonDTO.Type;
            existingPokemon.Type2 = newPokemonDTO.Type2;
            
            context.Update(existingPokemon);
            await context.SaveChangesAsync();

            var pokemonDTO = mapper.Map<PokemonDTO>(existingPokemon);

            return Ok(pokemonDTO);
        }
    }
}
