using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoochyDexApi.DTOs.Pokemon;
using PoochyDexApi.DTOs.VideoGame;
using PoochyDexApi.Entities;
using System.Text.Json;
using System.Threading.Tasks;

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

        [HttpGet("getAll")]
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

        [HttpGet("{id:int}", Name = "getVideoGame")]
        public async Task<ActionResult<VideoGameDTO>> Get(int id)
        {

            var videoGame = await context.VideoGames
                .Include(x => x.Generation)
                    .ThenInclude(g => g.VideoGames)
                .Include(x => x.ReleaseDates)
                .FirstOrDefaultAsync(x => x.Id == id);


            if (videoGame == null)
            {
                return NotFound();
            }

            return mapper.Map<VideoGameDTO>(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult> Post(NewVideoGameDTO newVideoGameDTO)
        {
            // Escapar los saltos de línea en gameHistory
            if (!string.IsNullOrEmpty(newVideoGameDTO.GameHistory))
            {
                newVideoGameDTO.GameHistory = EscapeSpecialCharacters(newVideoGameDTO.GameHistory);
            }

            // Escapar los saltos de línea en Summary
            if (!string.IsNullOrEmpty(newVideoGameDTO.Summary))
            {
                newVideoGameDTO.Summary = EscapeSpecialCharacters(newVideoGameDTO.Summary);
            }

            // Mapea el DTO a la entidad VideoGames
            var game = mapper.Map<VideoGames>(newVideoGameDTO);

            // Configura ReleaseDates en el objeto VideoGames
            if (newVideoGameDTO.ReleaseDates != null && newVideoGameDTO.ReleaseDates.Any())
            {
                // Asigna el VideoGameId a cada ReleaseDate
                foreach (var releaseDateDTO in newVideoGameDTO.ReleaseDates)
                {
                    // No necesitas asignar VideoGameId manualmente aquí,
                    // ya que se debería hacer en el mapper si es necesario.
                    // Si `VideoGameId` no debe estar presente en `ReleaseDateDTO`,
                    // quita esta asignación.
                    releaseDateDTO.VideoGameId = game.Id;
                }

                // Convierte ReleaseDatesDTO a ReleaseDate si es necesario
                var releaseDates = mapper.Map<List<ReleaseDate>>(newVideoGameDTO.ReleaseDates);
                game.ReleaseDates = releaseDates;
            }

            context.Add(game);
            await context.SaveChangesAsync();

            var gameDTO = mapper.Map<VideoGameDTO>(game);

            return CreatedAtRoute("getVideoGame", new { game.Id }, gameDTO);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<NewVideoGameDTO>> Put(int id, NewVideoGameDTO newVideoGameDTO)
        {
            var existingVideoGame = await context.VideoGames
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingVideoGame == null)
            {
                return NotFound("No se encuentra un juego con este ID");
            }

            // Mapear las propiedades del DTO al objeto existente
            mapper.Map(newVideoGameDTO, existingVideoGame);

            // Guardar los cambios en la base de datos
            await context.SaveChangesAsync();

            var gameDTO = mapper.Map<VideoGameDTO>(existingVideoGame);

            return CreatedAtRoute("getVideoGame", new { existingVideoGame.Id }, gameDTO);
        }

        private string EscapeSpecialCharacters(string input)
        {
            // Reemplaza saltos de línea con la secuencia escapada \\n
            return input.Replace("\n", "\\n").Replace("\r", "\\r");
        }

    }
    

}
