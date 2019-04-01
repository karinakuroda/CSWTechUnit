using Domain;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

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

      
        public void Remove(int id)
        {
            _projectRepository.Remove(id);
        }

    }
}
