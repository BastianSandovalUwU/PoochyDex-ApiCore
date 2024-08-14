using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Region")]
    public class RegionController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RegionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Region>>> Get()
        {
            return await context.Region
                                .Include(r => r.Generation)       // Incluir la relación Generation
                                    .ThenInclude(g => g.Games)    // Incluir la colección Games dentro de Generation
                                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Region region)
        {

            var existGeneration = await context.Region.AnyAsync(x => x.RegionName == region.RegionName);

            if (existGeneration)
            {
                return BadRequest($"ya existe una region con el nombre {region.RegionName}");
            }


            context.Add(region);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
