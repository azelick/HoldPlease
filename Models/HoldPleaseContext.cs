using Microsoft.EntityFrameworkCore;

namespace HoldPlease.Models
{
    public class HoldPleaseContext : DbContext
    {
        public HoldPleaseContext (DbContextOptions<HoldPleaseContext> options)
            : base(options)
        {
        }

        public DbSet<HoldPlease.Models.User> User { get; set; }
    }
}