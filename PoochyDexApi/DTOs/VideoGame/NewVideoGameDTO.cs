using PoochyDexApi.DTOs.ReleaseDate;
using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.VideoGame
{
    public class NewVideoGameDTO
    {
        public required int generationId { get; set; }
        public required int RegionId { get; set; }
        public required List<string> Games { get; set; }
        public required List<string> UrlFrontPage { get; set; }
        public required string Genre { get; set; }
        public required string Players { get; set; }
        public required string PublishedBy { get; set; }
        public required string DevelopedBy { get; set; }
        public required List<string> Platforms { get; set; }
        public string? GameHistory { get; set; }
        public string? Summary { get; set; }
        public List<ReleaseDateDTO>? ReleaseDates { get; set; }
    }
}
