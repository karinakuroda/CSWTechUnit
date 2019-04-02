using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        void Add(Project project);

        void Remove(int id);

        Task<List<Employee>> ListEmployeesByProjectId(int id);   
    }
}
