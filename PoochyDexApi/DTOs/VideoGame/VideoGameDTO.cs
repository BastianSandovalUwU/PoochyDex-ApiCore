﻿
using PoochyDexApi.DTOs.Generation;
using PoochyDexApi.Entities;

namespace PoochyDexApi.DTOs.VideoGame
{
    public class VideoGameDTO
    {
        public int generationId { get; set; }
        public GenerationDTO Generation { get; set; }
        public List<string> Games { get; set; }
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
