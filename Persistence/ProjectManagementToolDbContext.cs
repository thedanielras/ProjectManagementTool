using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using Persistence.SeedData;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Persistence
{
    public class ProjectManagementToolDbContext : DbContext
    {
        public ProjectManagementToolDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

        public DbSet<Project> Projects { get; set; }

    }
}
