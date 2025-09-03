using TexasWalks.API.Models.Domain;

namespace TexasWalks.API.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAllAsync(string filterOn = null, string filterQuery = null,
           string sortBy = null, bool isascending = true, int pageNumber = 1,
           int pageSize = 1000);

        Task<Walk> GetByIdAsync(Guid id);

        Task<Walk> UpdateAsync(Guid id, Walk walk);

        Task<Walk> DeleteAsync(Guid id);

    }
}
