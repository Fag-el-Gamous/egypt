using BYU_EGYPT.Models;
using Microsoft.EntityFrameworkCore;

namespace BYU_EGYPT.Data
{
    public class AWSDbContext: DbContext
    {
        public AWSDbContext(DbContextOptions<AWSDbContext> options) : base(options)
        {
        }
        public DbSet<CraniumAnalysisSheet> CraniumAnalysisSheet { get; set; }
    }
}
