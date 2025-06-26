using Microsoft.EntityFrameworkCore;
using TexasWalks.API.Models.Domain;

namespace TexasWalks.API.Data
{
    public class TexasVoxDBContext : DbContext
    {
        public TexasVoxDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties  { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}