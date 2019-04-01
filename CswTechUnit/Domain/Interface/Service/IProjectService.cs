using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        void Add(Project project);
        void Remove(int id);
        Task<IQueryable<Employee>> ListEmployeesByProjectId(int id);   
    }
}
