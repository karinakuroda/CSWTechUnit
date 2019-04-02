using Domain;
using Domain.Enum;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using Moq;
using Service;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class TestEmployee
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly IEmployeeService employeeService;
        public TestEmployee()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            employeeService = new EmployeeService(_mockEmployeeRepository.Object);
        }

        [Fact]
        public void ShouldCallAddOnlyOnce()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.AddEmployee(It.IsAny<Employee>()));
            //Act
            var resp = employeeService.AddEmployee(It.IsAny<Employee>());
            //Assert
            _mockEmployeeRepository.Verify(o => o.AddEmployee(It.IsAny<Employee>()), Times.Once());
        }

        [Fact]
        public void ShouldCallRemoveOnlyOnce()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.RemoveEmployee(It.IsAny<int>()));
            //Act
            var resp = employeeService.RemoveEmployee(It.IsAny<int>());
            //Assert
            _mockEmployeeRepository.Verify(o => o.RemoveEmployee(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ShouldCallUpdateOnlyOnce()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.UpdateEmployee(It.IsAny<Employee>()));
            //Act
            var resp = employeeService.UpdateEmployee(It.IsAny<Employee>());
            //Assert
            _mockEmployeeRepository.Verify(o => o.UpdateEmployee(It.IsAny<Employee>()), Times.Once());
        }

        [Fact]
        public void ShouldCallListProjectsByEmployeeIdOnlyOnce()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.ListProjectsByEmployeeId(It.IsAny<int>()));
            //Act
            var resp = employeeService.ListProjectsByEmployeeId(It.IsAny<int>());
            //Assert
            _mockEmployeeRepository.Verify(o => o.ListProjectsByEmployeeId(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ShouldCallListEmployeesOnlyOnce()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.ListEmployees());
            //Act
            var resp = employeeService.ListEmployees();
            //Assert
            _mockEmployeeRepository.Verify(o => o.ListEmployees(), Times.Once());
        }

        [Fact]
        public void ShouldCallGetByIdOnlyOnce()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.GetById(It.IsAny<int>()));
            //Act
            var resp = employeeService.GetById(It.IsAny<int>());
            //Assert
            _mockEmployeeRepository.Verify(o => o.GetById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ShouldReturnEmployeesList()
        {
            //Arrange
            _mockEmployeeRepository.Setup(s => s.ListEmployees()).ReturnsAsync(GetMockListEmployee());
            //Act
            var resp = employeeService.ListEmployees();
            //Assert
            resp.Result.Equals(GetMockListEmployee());
        }

        private static List<Employee> GetMockListEmployee()
        {
            var emp = new Employee(1, "teste", new System.DateTime(2019, 03, 03), RoleType.JE, PlatoonType.Fusion);
            var list = new List<Employee>();
            list.Add(emp);
            return list;
        }
    }
    
}
