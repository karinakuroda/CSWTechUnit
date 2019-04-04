using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain;
using Domain.Interfaces.Services;
using Domain.DTO;

namespace CswTechUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            this._projectService = projectService;
        }

        /// <summary>
        /// Add Project
        /// </summary>
        /// <param name="project"></param>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProjectDTO dto)
        {
            var project = new Project(dto.Name);
            
            if (project.IsValid())
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
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Project), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> Get(int id)
        {
            var response = await this._projectService.GetById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Project by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this._projectService.Remove(id);
            return NoContent();
        }

        /// <summary>
        /// List of Employees By Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Employees")]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Employee>>> Employees(int id)
        {
            var response = await this._projectService.ListEmployeesByProjectId(id);
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}
