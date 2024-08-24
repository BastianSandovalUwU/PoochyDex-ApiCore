using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Generation")]
    public class GenerationController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        //private readonly iServicio servicio;

        public GenerationController(ApplicationDbContext context)
        {
            this.context = context;
            //this.servicio = servicio;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Generation>> Get(int id)
        {
            var generation = await context.Generation
                                           .Include(g => g.VideoGames)
                                           .FirstOrDefaultAsync(x => x.Id == id);

            if (generation == null)
            {
                return NotFound();
            }

            return Ok(generation);
        }

        [HttpGet]
        public async Task<ActionResult<List<Generation>>> Get()
        {
            return await context.Generation
                                 .Include(g => g.VideoGames)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Generation generation)
        {

            var existGeneration = await context.Generation.AnyAsync(x => x.Name == generation.Name);

            if (existGeneration)
            {
                return BadRequest($"ya existe una generacion con el nombre {generation.Name}");
            }


            context.Add(generation);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
