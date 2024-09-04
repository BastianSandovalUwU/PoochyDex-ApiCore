using System.Text.Json.Serialization;

namespace PoochyDexApi.Entities
{
    public class Generation
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<VideoGames>? VideoGames { get; set; }
    }
}
