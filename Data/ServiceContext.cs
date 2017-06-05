using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoldPlease.Models;

    public class ServiceContext : DbContext
    {
        public ServiceContext (DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<HoldPlease.Models.Service> Service { get; set; }
    }
