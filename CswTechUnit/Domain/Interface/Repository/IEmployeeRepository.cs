using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployee(Employee employee);

        Task<int> RemoveEmployee(int id);

        Task<List<Employee>> ListEmployees();

        Task<int> UpdateEmployee(Employee employee);

        Task<Employee> GetById(int id);

        Task<List<Project>> ListProjectsByEmployeeId(int employeeId);
    }
}
