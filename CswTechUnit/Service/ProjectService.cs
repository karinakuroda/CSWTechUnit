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

        public Task<int> Add(Project project)
        {
           return this._projectRepository.Add(project);
        }

        public Task<Project> GetById(int id)
        {
            return this._projectRepository.GetById(id);
        }

        public Task<List<Employee>> ListEmployeesByProjectId(int id)
        {
           return this._projectRepository.ListEmployeesByProjectId(id);
        }

        public Task<int> Remove(int id)
        {
            return this._projectRepository.Remove(id);
        }
    }
}
