using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProjectAllocationService
    {
        Task<int> Add(ProjectAllocation dto);

        Task<int> Remove(int id);

        Task<ProjectAllocation> GetById(int id);
    }
}
