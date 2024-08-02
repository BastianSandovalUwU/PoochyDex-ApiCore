using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Games")]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GamesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Games>>> Get()
        {
            return await context.Games.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Games game)
        {

            var existGeneration = await context.Generation.AnyAsync(x => x.Name == game.GameName);

            if (existGeneration)
            {
                return BadRequest($"ya existe un uego con el nombre {game.GameName}");
            }


            context.Add(game);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
