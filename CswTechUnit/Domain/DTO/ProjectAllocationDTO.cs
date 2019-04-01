using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ProjectAllocationDTO
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int PercentageAllocation { get; set; }
    }
}
