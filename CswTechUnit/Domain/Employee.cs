using Domain.Enum;
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

        public Employee()
        {

        }

        public Employee(int id, string name, DateTime startDate, RoleType role, PlatoonType platoonType) : this(name, startDate, role, platoonType)
        {
            this.Id = id;
        }

        public Employee(string name, DateTime startDate, RoleType role, PlatoonType platoonType)
        {
            this.Name = name;
            this.Date = startDate;
            this.Role = role;
            this.Platoon = platoonType;
        }

        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(this.Name) && Date.Date > DateTime.MinValue && this.Role > 0 && this.Platoon > 0)
                return true;

            return false;
        }
    }
}
