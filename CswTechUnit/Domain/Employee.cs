using Domain.Enum;
using System;
using System.Collections.Generic;

//TODO: Put the name of the projects at namespace, I think this can be configurable in csproj
namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public RoleType Role { get; set; }

        public PlatoonType Platoon { get; set; }

        public List<ProjectAllocation> ProjectAllocations { get; set; }
    }
}
