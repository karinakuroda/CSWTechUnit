using Domain.Enum;
using System;

namespace Domain.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int RoleId { get; set; }

        public int PlatoonId { get; set; }
    }
}
