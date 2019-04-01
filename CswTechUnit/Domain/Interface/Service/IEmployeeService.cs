using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(int id);
        List<Employee> ListEmployees();
        void UpdateEmployee(Employee employee);
        Employee GetById(int id);
    }
}
