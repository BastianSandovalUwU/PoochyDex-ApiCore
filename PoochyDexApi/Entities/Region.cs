namespace PoochyDexApi.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int GenerationId { get; set; }
        public Generation Generation { get; set; }

}
}
