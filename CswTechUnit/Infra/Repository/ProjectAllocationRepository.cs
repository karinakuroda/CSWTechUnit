using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Interface.Repository;

namespace Infra.Repository
{
    public class ProjectAllocationRepository : IProjectAllocationRepository
    {
        private CswContext _context;

        public ProjectAllocationRepository(CswContext context)
        {
            this._context = context;
        }
        public Task<int> Add(ProjectAllocation project)
        {
            this._context.Add(project);
            return this._context.SaveChangesAsync();
        }
        
        public Task<int> Remove(int id)
        {
            var project = GetById(id);
            this._context.Remove(project);
            return this._context.SaveChangesAsync();
        }
        public Task<ProjectAllocation> GetById(int id)
        {
            return this._context.ProjectAllocations.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
