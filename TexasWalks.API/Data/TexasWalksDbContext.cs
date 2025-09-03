using Microsoft.EntityFrameworkCore;
using TexasWalks.API.Domain;
using TexasWalks.API.Models.Domain;

namespace TexasWalks.API.Data
{
    public class TexasWalksDbContext : DbContext
    {
        public TexasWalksDbContext(DbContextOptions<TexasWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("3dcf8f49-d451-4c87-a270-365c1da9d2c1"),
                    Name = "Easy"
                    
                },
                new Difficulty()
                {
                    Id = Guid.Parse("2741d36f-4932-4448-8f78-ab458f163fad"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("6ace00c4-4ac4-4b69-b832-965438d482c0"),
                    Name = "Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f959f132-ff89-4ca5-a870-b6e5b4eec0c4"),
                    Name = "Coppel",
                    Code = "COP",
                    RegionImageUrl = "image.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("f6874358-c635-4b21-a401-b5c3f6eafec2"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "image.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("132f75be-ab4c-460a-821e-149e7899c5b9"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "image.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("0b42603b-e20a-4365-9996-042057541580"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "image.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("8a34d69b-e451-489b-b37a-830687ca47d8"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "image.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("2ff57e7d-2a87-4038-92b3-6907fd9f3da6"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "image.jpg"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
