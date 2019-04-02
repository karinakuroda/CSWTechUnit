using Domain;
using Domain.DTO;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectAllocationService : IProjectAllocationService
    {
        private IProjectAllocationRepository _projectAllocationRepository;

        public ProjectAllocationService(IProjectAllocationRepository projectAllocationRepository)
        {
            this._projectAllocationRepository = projectAllocationRepository;
        }

        public Task<int> Add(ProjectAllocation projectAllocation)
        {
      
            return this._projectAllocationRepository.Add(projectAllocation);
        }
         
        public Task<ProjectAllocation> GetById(int id)
        {
            return this._projectAllocationRepository.GetById(id);
        }

        public Task<int> Remove(int id)
        {
           return this._projectAllocationRepository.Remove(id);
        }
    }
}
