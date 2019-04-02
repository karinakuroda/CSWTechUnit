using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            this._employeeRepository.AddEmployee(employee);
        }

        public Task<List<Employee>> ListEmployees()
        {
           return this._employeeRepository.ListEmployees();
        }

        public void RemoveEmployee(int id)
        {
            this._employeeRepository.RemoveEmployee(id);
        }
        
        public void UpdateEmployee(Employee employee)
        {
            this._employeeRepository.UpdateEmployee(employee);
        }

        public Employee GetById(int id)
        {
           return this._employeeRepository.GetById(id);
        }

        public Task<List<Project>> ListProjectsByEmployeeId(int employeeId)
        {
            return this._employeeRepository.ListProjectsByEmployeeId(employeeId);
        }
    }
}
