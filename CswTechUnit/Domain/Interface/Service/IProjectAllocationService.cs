using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IProjectAllocationService
    {
        void Add(ProjectAllocationDTO dto);
        void Remove(int id);
    }
}
