using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;

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
            this._projectRepository.Add(project);
        }

        public Task<List<Employee>> ListEmployeesByProjectId(int id)
        {
           return this._projectRepository.ListEmployeesByProjectId(id);
        }

        public void Remove(int id)
        {
            this._projectRepository.Remove(id);
        }
    }
}
