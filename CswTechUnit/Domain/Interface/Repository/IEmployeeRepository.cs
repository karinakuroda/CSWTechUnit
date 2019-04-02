using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);

        void RemoveEmployee(int id);

        Task<List<Employee>> ListEmployees();

        void UpdateEmployee(Employee employee);

        Employee GetById(int id);

        Task<List<Project>> ListProjectsByEmployeeId(int employeeId);
    }
}
