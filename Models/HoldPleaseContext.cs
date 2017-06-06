using Microsoft.EntityFrameworkCore;
using HoldPlease.Models;

namespace HoldPlease.Models
{
    public class HoldPleaseContext : DbContext
    {
        public HoldPleaseContext (DbContextOptions<HoldPleaseContext> options)
            : base(options)
        {
        }

        // public DbSet<HoldPlease.Models.User> User { get; set; }

        public DbSet<HoldPlease.Models.Service> Service { get; set; }
    }
}
