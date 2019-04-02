using System.Linq;
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
        public void Add(ProjectAllocation project)
        {
            this._context.Add(project);
            this._context.SaveChanges();
        }
        
        public void Remove(int id)
        {
            var project = GetById(id);
            this._context.Remove(project);
            this._context.SaveChanges();
        }
        private ProjectAllocation GetById(int id)
        {
            return this._context.ProjectAllocations.SingleOrDefault(s => s.Id == id);
        }
    }
}
