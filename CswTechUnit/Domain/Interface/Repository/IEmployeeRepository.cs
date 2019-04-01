using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface.Repository
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(int id);
        List<Employee> ListEmployees();
        void UpdateEmployee(Employee employee);
        Employee GetById(int id);
    }
}
