using Domain;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

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
            _employeeRepository.AddEmployee(employee);
        }

        public List<Employee> ListEmployees()
        {
           return _employeeRepository.ListEmployees();
        }

        public void RemoveEmployee(int id)
        {
            _employeeRepository.RemoveEmployee(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }
        public Employee GetById(int id)
        {
           return _employeeRepository.GetById(id);
        }
    }
}
