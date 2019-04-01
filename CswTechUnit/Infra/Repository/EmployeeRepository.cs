using Domain;
using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
