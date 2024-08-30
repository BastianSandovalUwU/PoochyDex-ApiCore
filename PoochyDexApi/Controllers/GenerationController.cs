﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Generation;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Generation")]
    public class GenerationController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerationController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
        public async Task<ActionResult> Post(NewGenerationDTO newGenerationDTO)
        {

            var existGeneration = await context.Generation.AnyAsync(x => x.Name == newGenerationDTO.Name);

            if (existGeneration)
            {
                return BadRequest($"ya existe una generacion con el nombre {newGenerationDTO.Name}");
            }
            
            var pokemon = mapper.Map<Generation>(newGenerationDTO);

            context.Add(pokemon);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
