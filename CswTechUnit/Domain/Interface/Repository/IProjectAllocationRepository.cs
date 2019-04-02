using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IProjectAllocationRepository
    {
        Task<int> Add(ProjectAllocation project);

        Task<int> Remove(int id);

        Task<ProjectAllocation> GetById(int id);
    }
}
