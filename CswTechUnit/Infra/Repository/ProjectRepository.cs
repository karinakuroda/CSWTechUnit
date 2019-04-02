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
        public Task<int> Add(Project project)
        {
            this._context.Add(project);
            return this._context.SaveChangesAsync();
        }

        public async Task<List<Employee>> ListEmployeesByProjectId(int id)
        {
            return (await this._context.Set<Employee>()
                    .Where(ww => ww.ProjectAllocations.Where(w => w.ProjectId == id).Any())
                    .ToListAsync());
        }

        public Task<int> Remove(int id)
        {
            var project = GetById(id);
            this._context.Remove(project);
            return this._context.SaveChangesAsync();
        }

        public Task<Project> GetById(int id)
        {
            return this._context.Projects.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
