using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(int id);
        List<Employee> ListEmployees();
        void UpdateEmployee(Employee employee);
        Employee GetById(int id);
        Task<IQueryable<Project>> ListProjectsByEmployeeId(int employeeId);
    }
}
