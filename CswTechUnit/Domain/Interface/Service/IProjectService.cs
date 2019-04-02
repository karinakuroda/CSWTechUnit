using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        Task<int> Add(Project project);

        Task<int> Remove(int id);

        Task<Project> GetById(int id);

        Task<List<Employee>> ListEmployeesByProjectId(int id);
    }
}
