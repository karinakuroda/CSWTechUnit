using Domain;
using Domain.Interface.Repository;
using System.Collections.Generic;
using System.Linq;

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
            _context.Add(project);
            _context.SaveChanges();
        }
        
        public void Remove(int id)
        {
            var project = GetById(id);
            _context.Remove(project);
            _context.SaveChanges();
        }
        private ProjectAllocation GetById(int id)
        {
            return _context.ProjectAllocations.SingleOrDefault(s => s.Id == id);
        }
    }
}
