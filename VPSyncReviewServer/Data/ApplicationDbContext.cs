using Microsoft.EntityFrameworkCore;
using VPSyncReviewServer.Models;

namespace VPSyncReviewServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
    }
}