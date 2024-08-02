using System.Text.Json.Serialization;

namespace PoochyDexApi.Entities
{
    public class Generation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Games>? Games { get; set; }
    }
}
