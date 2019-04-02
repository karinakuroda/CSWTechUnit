using Domain;
using Domain.DTO;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;

namespace Service
{
    public class ProjectAllocationService : IProjectAllocationService
    {
        private IProjectAllocationRepository _projectAllocationRepository;

        public ProjectAllocationService(IProjectAllocationRepository projectAllocationRepository)
        {
            this._projectAllocationRepository = projectAllocationRepository;
        }

        public void Add(ProjectAllocationDTO dto)
        {
            var projectAllocation = new ProjectAllocation(dto.ProjectId, dto.EmployeeId, dto.PercentageAllocation);
            this._projectAllocationRepository.Add(projectAllocation);
        }
        
        public void Remove(int id)
        {
            this._projectAllocationRepository.Remove(id);
        }
    }
}
