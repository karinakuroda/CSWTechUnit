using Domain;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CswContext _context;

        public EmployeeRepository(CswContext context)
        {
            this._context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.SingleOrDefault(s=>s.Id==id);
        }

        public List<Employee> ListEmployees()
        {
            return _context.Employees.ToList();
        }

        public async Task<IQueryable<Project>> ListProjectsByEmployeeId(int employeeId)
        {
            return (await this._context.Set<Project>()
              //.Include(i=>i.Project)
               .Where(ww=>ww.ProjectAllocations.Where(w=>w.EmployeeId==employeeId).Any())
               .ToListAsync())
               .AsQueryable();
        }

        public void RemoveEmployee(int id)
        {
            var emp = GetById(id);
            _context.Remove(emp);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var old = GetById(employee.Id);
            _context.Entry(old).CurrentValues.SetValues(employee);
            _context.SaveChanges();

        }
    }
}
