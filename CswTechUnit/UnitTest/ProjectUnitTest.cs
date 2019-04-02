using Moq;
using Service;
using System.Collections.Generic;
using Xunit;
using Domain;
using Domain.Enum;
using Domain.Interface.Repository;
using Domain.Interfaces.Services;

namespace UnitTest
{
    public class ProjectUnitTest
    {
        private readonly Mock<IProjectRepository> _mockProjectRepository;
        private readonly IProjectService projectService;

        public ProjectUnitTest()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            projectService = new ProjectService(_mockProjectRepository.Object);
        }

        [Fact]
        public void ShouldCallAddOnlyOnce()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.Add(It.IsAny<Project>()));
            //Act
            var resp = projectService.Add(It.IsAny<Project>());
            //Assert
            _mockProjectRepository.Verify(o => o.Add(It.IsAny<Project>()), Times.Once());
        }

        [Fact]
        public void ShouldCallRemoveOnlyOnce()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.Remove(It.IsAny<int>()));
            //Act
            var resp = projectService.Remove(It.IsAny<int>());
            //Assert
            _mockProjectRepository.Verify(o => o.Remove(It.IsAny<int>()), Times.Once());
        }
        
        [Fact]
        public void ShouldCallGetByIdOnlyOnce()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.GetById(It.IsAny<int>()));
            //Act
            var resp = projectService.GetById(It.IsAny<int>());
            //Assert
            _mockProjectRepository.Verify(o => o.GetById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ShouldReturnEmployeesList()
        {
            //Arrange
            _mockProjectRepository.Setup(s => s.ListEmployeesByProjectId(It.IsAny<int>())).ReturnsAsync(GetMockListEmployee());
            //Act
            var resp = projectService.ListEmployeesByProjectId(It.IsAny<int>());
            //Assert
            resp.Result.Count.Equals(2);
        }
        
        private static List<Employee> GetMockListEmployee()
        {
            var joao = new Employee(1, "teste", new System.DateTime(2019, 03, 03), RoleType.JE, PlatoonType.Fusion);
            var maria = new Employee(2, "teste 2", new System.DateTime(2019,03,03), RoleType.JE,PlatoonType.Fusion);
            var list = new List<Employee>();
            list.Add(joao);
            list.Add(maria);
            return list;
        }
    }
}
