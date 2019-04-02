using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Interface.Repository;

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

        public async Task<List<Employee>> ListEmployeesByProjectId(int id)
        {
            return (await this._context.Set<Employee>()
                    .Where(ww => ww.ProjectAllocations.Where(w => w.ProjectId == id).Any())
                    .ToListAsync());
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
