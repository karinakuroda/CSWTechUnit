using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
            _projectService.Add(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectService.Remove(id);
        }
        [HttpGet("{id}/Employees")]
        public async Task<IQueryable<Employee>> Employees(int id)
        {
            return await _projectService.ListEmployeesByProjectId(id);
        }
    }
}
