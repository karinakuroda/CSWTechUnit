using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Enum;
using System.Collections.Generic;

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
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<Platoon> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Role> roleList = new List<Role>();
            roleList.Add(new Role { Id = 1, Name = "JE" });
            roleList.Add(new Role { Id = 2, Name = "PE" });
            roleList.Add(new Role { Id = 3, Name = "SE" });
            
            List<Platoon> platoonsList = new List<Platoon>();
            platoonsList.Add(new Platoon { Id= 1, Name= "Alchemists" });
            platoonsList.Add(new Platoon { Id= 2, Name= "Borg" });
            platoonsList.Add(new Platoon { Id= 3, Name= "DeliveryOffice" });
            platoonsList.Add(new Platoon { Id= 4, Name= "Fusion" });
            platoonsList.Add(new Platoon { Id= 5, Name= "Jedi" });
            platoonsList.Add(new Platoon { Id= 6, Name= "Klingon" });
            platoonsList.Add(new Platoon { Id= 7, Name= "Machimbombo" });
            platoonsList.Add(new Platoon { Id= 8, Name= "Patinhas" });
            platoonsList.Add(new Platoon { Id= 9, Name= "Rebels" });
            platoonsList.Add(new Platoon { Id= 10, Name= "Skywalkers" });
            platoonsList.Add(new Platoon { Id= 11, Name= "Spartans" });
            platoonsList.Add(new Platoon { Id= 12, Name= "Species" });
            platoonsList.Add(new Platoon { Id= 13, Name= "Typhoon" });
            platoonsList.Add(new Platoon { Id= 14, Name= "Vision" });
            platoonsList.Add(new Platoon { Id = 15, Name = "Vulcan" });

            modelBuilder.Entity<Platoon>().HasData(platoonsList.ToArray());
            modelBuilder.Entity<Role>().HasData(roleList.ToArray());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
