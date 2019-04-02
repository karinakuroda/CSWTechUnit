using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Interfaces.Services;

namespace CswTechUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            this._projectService = projectService;
        }

        [HttpPost]
        public void Post([FromBody] Project value)
        {
            this._projectService.Add(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._projectService.Remove(id);
        }
        [HttpGet("{id}/Employees")]
        public async Task<List<Employee>> Employees(int id)
        {
            return await this._projectService.ListEmployeesByProjectId(id);
        }
    }
}
