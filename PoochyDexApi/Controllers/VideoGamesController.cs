using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.VideoGame;
using PoochyDexApi.Entities;
using System.Text.Json;

namespace PoochyDexApi.Controllers
{
    [ApiController]
    [Route("api/Games")]
    public class VideoGamesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VideoGamesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGameDTO>>> Get()
        {
            try
            {
                var games = await context.VideoGames
                    .Include(x => x.Generation)
                    .Include(x => x.ReleaseDates).ToListAsync();
                var gamesDTO = mapper.Map<List<VideoGameDTO>>(games);
                return Ok(gamesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los videojuegos: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(NewVideoGameDTO newVideoGameDTO)
        {
            // Escapar los saltos de línea en gameHistory
            if (!string.IsNullOrEmpty(newVideoGameDTO.GameHistory))
            {
                newVideoGameDTO.GameHistory = EscapeSpecialCharacters(newVideoGameDTO.GameHistory);
            }

            // Puedes hacer lo mismo para otros campos que puedan contener saltos de línea
            if (!string.IsNullOrEmpty(newVideoGameDTO.Summary))
            {
                newVideoGameDTO.Summary = EscapeSpecialCharacters(newVideoGameDTO.Summary);
            }

            var game = mapper.Map<VideoGames>(newVideoGameDTO);
            context.Add(game);
            await context.SaveChangesAsync();
            return Ok();
        }

        private string EscapeSpecialCharacters(string input)
        {
            // Reemplaza saltos de línea con la secuencia escapada \\n
            return input.Replace("\n", "\\n").Replace("\r", "\\r");
        }

    }
    

}
