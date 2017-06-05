using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HoldPlease.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new HoldPleaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<HoldPleaseContext>>());
            context.Database.EnsureCreated();
        }
    }
}