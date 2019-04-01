﻿using Domain.Enum;
using System;
using System.Collections.Generic;

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
    public class ProjectAllocation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int PercentageAllocation { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }

    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<ProjectAllocation> ProjectAllocations { get; set; }
    }
  
   
}