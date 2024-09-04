using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Region;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Region")]
    public class RegionController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RegionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<RegionDTO>>> Get()
        {
            var region = await context.Region
                                .Include(r => r.Generation)       // Incluir la relación Generation
                                    .ThenInclude(g => g.VideoGames)    // Incluir la colección Games dentro de Generation
                                .ToListAsync();

            return mapper.Map<List<RegionDTO>>(region);
        }

        [HttpPost]
        public async Task<ActionResult> Post(NewRegionDTO newRegionDTO)
        {

            var existGeneration = await context.Region.AnyAsync(x => x.RegionName == newRegionDTO.RegionName);

            if (existGeneration)
            {
                return BadRequest($"ya existe una region con el nombre {newRegionDTO.RegionName}");
            }

            var region = mapper.Map<Region>(newRegionDTO);

            context.Add(region);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
