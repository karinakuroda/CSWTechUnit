using Domain;
using Domain.Interface.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private CswContext _context;

        public ProjectRepository(CswContext context)
        {
            this._context = context;
        }
        public void Add(Project project)
        {
            _context.Add(project);
            _context.SaveChanges();
        }

       
        public void Remove(int id)
        {
            var project = GetById(id);
            _context.Remove(project);
            _context.SaveChanges();
        }
        private Project GetById(int id)
        {
            return _context.Projects.SingleOrDefault(s => s.Id == id);
        }


    }
}
