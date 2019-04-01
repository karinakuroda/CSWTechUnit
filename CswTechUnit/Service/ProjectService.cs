using Domain;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public void Add(Project project)
        {
            _projectRepository.Add(project);
        }

        public Task<IQueryable<Employee>> ListEmployeesByProjectId(int id)
        {
           return _projectRepository.ListEmployeesByProjectId(id);
        }

        public void Remove(int id)
        {
            _projectRepository.Remove(id);
        }
    }
}
