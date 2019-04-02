using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(Employee employee);

        Task<int> RemoveEmployee(int id);

        Task<int> UpdateEmployee(Employee employee);

        Task<Employee> GetById(int id);

        Task<List<Employee>> ListEmployees();

        Task<List<Project>> ListProjectsByEmployeeId(int employeeId);
    }
}
