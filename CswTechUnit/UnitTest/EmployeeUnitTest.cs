using CswTechUnit.Controllers;
using CswTechUnit.DTO;
using Domain;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class EmployeeUnitTest
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly EmployeesController _employeeController;

        private readonly IEmployeeService employeeService;

        public EmployeeUnitTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockEmployeeService= new Mock<IEmployeeService>();
            _employeeController = new EmployeesController(_mockEmployeeService.Object);
            employeeService = new EmployeeService(_mockEmployeeRepository.Object);
        }

        [Fact]
        public async Task ShouldReturnBadRequestWhenInvalidAdd()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.AddEmployee(new Employee()));
            //Act
            var resp = await _employeeController.Post(new EmployeeDTO());
            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(resp);
        }

        [Fact]
        public async Task ShouldReturnOkWhenValidAdd()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.AddEmployee(new Employee()));
            //Act
            var resp = await _employeeController.Post(GetValidEmployeeDTO());
            //Assert
            var badRequestResult = Assert.IsType<CreatedAtActionResult>(resp);
        }

        [Fact]
        public async Task ShouldReturnBadRequestWhenInvalidUpdate()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.UpdateEmployee(new Employee()));
            //Act
            var resp = await _employeeController.Put(1, new EmployeeDTO());
            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(resp);
        }

        [Fact]
        public async Task ShouldReturnNoContentWhenValidUpdate()
        {
            //Arrange
            _mockEmployeeService.Setup(s => s.UpdateEmployee(new Employee()));
            //Act
            var resp = await _employeeController.Put(1, GetValidEmployeeDTO());
            //Assert
            var badRequestResult = Assert.IsType<NoContentResult>(resp);
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
            var emp = new Employee(1, "teste", new System.DateTime(2019, 03, 03), 1, 1);
            var list = new List<Employee>();
            list.Add(emp);
            return list;
        }

        private static EmployeeDTO GetValidEmployeeDTO()
        {
            var dto = new EmployeeDTO();
            dto.Name = "Teste ABC";
            dto.StartDate = DateTime.Now;
            dto.RoleId = 1;
            dto.PlatoonId = 1;
            return dto;
        }
    }
}
