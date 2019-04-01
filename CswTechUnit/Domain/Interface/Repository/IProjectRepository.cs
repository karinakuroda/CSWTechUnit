using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IProjectRepository
    {
        void Add(Project project);
        void Remove(int id);
        Task<IQueryable<Employee>> ListEmployeesByProjectId(int id);
    }
}

