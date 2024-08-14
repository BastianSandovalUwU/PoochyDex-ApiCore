using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PokemonController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<PokemonList>>> Get()
        {
            return await context.PokemonList.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PokemonList>> Get(int id)
        {
            var pokemon = await context.PokemonList.FirstOrDefaultAsync(x => x.Number == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PokemonList pokemon)
        {

            var existePokemon = await context.PokemonList.AnyAsync(x => x.Name == pokemon.Name);

            if (existePokemon)
            {
                return BadRequest($"ya existe un pokemon con el nombre {pokemon.Name}");
            }


            context.Add(pokemon);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
