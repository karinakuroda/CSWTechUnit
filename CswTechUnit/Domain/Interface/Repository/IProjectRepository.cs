using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IProjectRepository
    {
        Task<int> Add(Project project);

        Task<int> Remove(int id);

        Task<Project> GetById(int id);

        Task<List<Employee>> ListEmployeesByProjectId(int id);
    }
}

