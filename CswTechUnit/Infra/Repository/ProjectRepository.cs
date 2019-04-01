using Domain;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IQueryable<Employee>> ListEmployeesByProjectId(int id)
        {
            return (await this._context.Set<Employee>()
                    .Where(ww => ww.ProjectAllocations.Where(w => w.ProjectId == id).Any())
                    .ToListAsync())
                    .AsQueryable();
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
