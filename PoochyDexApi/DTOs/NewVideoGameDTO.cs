using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs
{
    public class NewVideoGameDTO
    {
        public string Generation { get; set; }
        public List<string> GamesList { get; set; }
        public List<string> UrlFrontPage { get; set; }
        public string Genre { get; set; }
        public string Players { get; set; }
        public string PublishedBy { get; set; }
        public string DevelopedBy { get; set; }
        public List<string> Platforms { get; set; }
        public string GameHistory { get; set; }
        public string Characters { get; set; }
        public string Summary { get; set; }
        public List<ReleaseDate> ReleaseDates { get; set; }
    }
}
