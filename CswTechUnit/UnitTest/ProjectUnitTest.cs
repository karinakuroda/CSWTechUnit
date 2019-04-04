using Moq;
using Service;
using System.Collections.Generic;
using Xunit;
using Domain;
using Domain.Enum;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using CswTechUnit.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;

namespace UnitTest
{
    public class ProjectUnitTest
    {
        private readonly Mock<IProjectRepository> _mockProjectRepository;

        private readonly Mock<IProjectService> _mockProjectService;

        private readonly ProjectsController _projectController;

        private readonly IProjectService _projectService;

        public ProjectUnitTest()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            _mockProjectService = new Mock<IProjectService>();
            _projectService = new ProjectService(_mockProjectRepository.Object);
            _projectController = new ProjectsController(_mockProjectService.Object);
        }

        [Fact]
        public void ShouldCallAddOnlyOnce()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.Add(It.IsAny<Project>()));
            //Act
            var resp = _projectService.Add(It.IsAny<Project>());
            //Assert
            _mockProjectRepository.Verify(o => o.Add(It.IsAny<Project>()), Times.Once());
        }

        [Fact]
        public void ShouldCallRemoveOnlyOnce()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.Remove(It.IsAny<int>()));
            //Act
            var resp = _projectService.Remove(It.IsAny<int>());
            //Assert
            _mockProjectRepository.Verify(o => o.Remove(It.IsAny<int>()), Times.Once());
        }
        
        [Fact]
        public void ShouldCallGetByIdOnlyOnce()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.GetById(It.IsAny<int>()));
            //Act
            var resp = _projectService.GetById(It.IsAny<int>());
            //Assert
            _mockProjectRepository.Verify(o => o.GetById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ShouldReturnEmployeesList()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.ListEmployeesByProjectId(It.IsAny<int>())).ReturnsAsync(GetMockListEmployee());
            //Act
            var resp = _projectService.ListEmployeesByProjectId(It.IsAny<int>());
            //Assert
            resp.Result.Count.Equals(2);
        }

        [Fact]
        public async Task ShouldReturnBadRequestWhenInvalidAdd()
        {
            //Act
            var resp = await _projectController.Post(new ProjectDTO());
            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(resp);
        }

        [Fact]
        public async Task ShouldReturnOkWhenValidAdd()
        {
            //Act
            var resp = await _projectController.Post(new ProjectDTO { Name = "PROJETO ABC"});
            //Assert
             Assert.IsType<CreatedAtActionResult>(resp);
        }

        private static List<Employee> GetMockListEmployee()
        {
            var joao = new Employee(1, "teste", new System.DateTime(2019, 03, 03), 1, 1);
            var maria = new Employee(2, "teste 2", new System.DateTime(2019,03,03), 1,1);
            var list = new List<Employee>();
            list.Add(joao);
            list.Add(maria);
            return list;
        }
    }
}
