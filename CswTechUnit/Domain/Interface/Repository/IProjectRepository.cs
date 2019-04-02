using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IProjectRepository
    {
        void Add(Project project);

        void Remove(int id);

        Task<List<Employee>> ListEmployeesByProjectId(int id);
    }
}

