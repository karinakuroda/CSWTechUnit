using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// Add Project
        /// </summary>
        /// <param name="project"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Project), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Project project)
        {
            var validation = project.Name != "";
            if (validation)
            {
                await this._projectService.Add(project);
                return CreatedAtAction(nameof(this.Get), new { id = project.Id }, project);
            }
            return BadRequest();
        }
        /// <summary>
        /// Get Project by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            return await this._projectService.GetById(id);
        }

        /// <summary>
        /// Delete Project by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._projectService.Remove(id);
        }

        /// <summary>
        /// List of Employees By Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Employees")]
        public async Task<List<Employee>> Employees(int id)
        {
            return await this._projectService.ListEmployeesByProjectId(id);
        }
    }
}
