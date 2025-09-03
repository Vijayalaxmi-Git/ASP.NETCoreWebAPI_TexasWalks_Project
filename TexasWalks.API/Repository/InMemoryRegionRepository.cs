using TexasWalks.API.Models.Domain;

namespace TexasWalks.API.Repository
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public  InMemoryRegionRepository()
        {

        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                    new Region()
                    {
                        Id = Guid.NewGuid(),
                        Code = "HC",
                        Name = "HillCounty",
                        RegionImageUrl = "image-Hill.jpg"
                    }

            };
            //If u comment above return statement, then uncomment below return statement
            //return Task.FromResult(new List<Region>());

        }
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}