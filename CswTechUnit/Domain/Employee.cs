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

        public Role Role { get; set; }

        public int RoleId { get; set; }

        public int PlatoonId { get; set; }

        public Platoon Platoon { get; set; }

        public List<ProjectAllocation> ProjectAllocations { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string name, DateTime startDate, int roleId, int platoonId) : this(name, startDate, roleId, platoonId)
        {
            this.Id = id;
        }

        public Employee(string name, DateTime startDate, int roleId, int platoonId)
        {
            this.Name = name;
            this.Date = startDate;
            this.RoleId = roleId;
            this.PlatoonId = platoonId;
        }

        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(this.Name) && this.Date.Date > DateTime.MinValue && this.RoleId > 0 && this.PlatoonId > 0)
                return true;

            return false;
        }
    }
}
