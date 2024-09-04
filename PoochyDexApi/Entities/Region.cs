namespace PoochyDexApi.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public required string RegionName { get; set; }
        public required int GenerationId { get; set; }
        public Generation? Generation { get; set; }

}
}
