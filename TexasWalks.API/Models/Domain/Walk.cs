namespace TexasWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public double lenghtInKm {  get; set; }
        public string? WalkImageUrl {  get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
        //navigation properties
        public string Difficulty { get; set; }
        public string Region {  get; set; }
    }
}
