using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        
        void RemoveEmployee(int id);
        
        void UpdateEmployee(Employee employee);

        Employee GetById(int id);

        Task<List<Employee>> ListEmployees();

        Task<List<Project>> ListProjectsByEmployeeId(int employeeId);
    }
}
