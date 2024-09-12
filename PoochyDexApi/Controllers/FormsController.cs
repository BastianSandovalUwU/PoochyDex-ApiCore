using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Forms;
using PoochyDexApi.DTOs.Pokemon;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Forms")]
    public class FormsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FormsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<FormsDTO>>> Get()
        {
            var forms = await context.Forms
            .Include(f => f.Pokemon) // Incluye el Pokémon relacionado
            .Include(f => f.PokemonForms) // Incluye los formularios del Pokémon
            .ToListAsync();

            var formDTOs = mapper.Map<List<FormsDTO>>(forms);

            return Ok(formDTOs);
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> Post(int id, NewFormDTO newFormDTO)
        {
            var pokemonExist = await context.Pokemon.AnyAsync(x => x.Id == id);

            if (!pokemonExist) 
            { 
                return BadRequest("Ese pokemon no existe");
            }

            var form = mapper.Map<Forms>(newFormDTO);
            context.Add(form);
            await context.SaveChangesAsync();
            return Ok(form);
        }
    }
}
