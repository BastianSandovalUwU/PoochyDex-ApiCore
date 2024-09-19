using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Forms;
using PoochyDexApi.DTOs.Pokemon;
using PoochyDexApi.DTOs.Sprites;
using PoochyDexApi.Entities;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/HomeSprites")]
    public class HomeSpritesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeSpritesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(HomeSpritesDTO spritesDTO) {

                var sprites = mapper.Map<HomeSprites>(spritesDTO);
                context.Add(sprites);
                await context.SaveChangesAsync();
                return Ok(sprites);

        }
    
    }
}