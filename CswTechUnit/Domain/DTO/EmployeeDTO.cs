using Domain.Enum;
using System;

namespace Domain.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public RoleType Role { get; set; }

        public PlatoonType Platoon { get; set; }
    }
}
