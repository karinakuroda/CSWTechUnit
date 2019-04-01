using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(int id);
        List<Employee> ListEmployees();
        void UpdateEmployee(Employee employee);
        Employee GetById(int id);
        Task<IQueryable<Project>> ListProjectsByEmployeeId(int employeeId);
    }
}
