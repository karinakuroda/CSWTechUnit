using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra
{
    public class CswContext : DbContext
    {
        public CswContext(DbContextOptions<CswContext> options)
          : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAllocation> ProjectAllocations { get; set; }
    }
}
