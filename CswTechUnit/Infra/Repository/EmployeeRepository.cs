using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Interface.Repository;
using Domain.Enum;

namespace Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CswContext _context;

        public EmployeeRepository(CswContext context)
        {
            this._context = context;
        }

        public Task<int> AddEmployee(Employee employee)
        {
            this._context.Add(employee);
            var rowsAffected = this._context.SaveChangesAsync();
            return rowsAffected;
        }

        public Task<Employee> GetById(int id)
        {
            return ( this._context.Set<Employee>()
             .Include(i => i.Platoon)
             .Include(i=>i.Role)
             .SingleOrDefaultAsync(s => s.Id == id));
        }

        public Task<List<Employee>> ListEmployees()
        {
            return this._context.Employees.ToListAsync();
        }

        public async Task<List<Project>> ListProjectsByEmployeeId(int employeeId)
        {
            return (await this._context.Set<Project>()
               .Where(w=>w.ProjectAllocations.Where(allocation=> allocation.EmployeeId==employeeId).Any())
               .ToListAsync());
        }

        public async Task<int> RemoveEmployee(int id)
        {
            var emp = await GetById(id);
            this._context.Remove(emp);
            return await this._context.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var old = await GetById(employee.Id);
            this._context.Entry(old).CurrentValues.SetValues(employee);
            return await this._context.SaveChangesAsync();
        }
    }
}
