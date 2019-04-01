namespace Domain
{
    public class ProjectAllocation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public decimal PercentageAllocation { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }

        public ProjectAllocation(int projectId, int employeeId, decimal percentageAllocation)
        {
            this.ProjectId = projectId;
            this.EmployeeId = employeeId;
            this.PercentageAllocation = percentageAllocation;
        }
    }
}
