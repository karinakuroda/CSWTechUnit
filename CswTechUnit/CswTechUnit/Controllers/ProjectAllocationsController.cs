using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Interfaces.Services;
using Domain;
using CswTechUnit.DTO;

namespace CswTechUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAllocationsController : ControllerBase
    {
        private readonly IProjectAllocationService _projectAllocationService;

        public ProjectAllocationsController(IProjectAllocationService projectAllocationService)
        {
            this._projectAllocationService = projectAllocationService;
        }

        /// <summary>
        /// Add Project Allocation
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProjectAllocationDTO dto)
        {
            var projectAllocation = new ProjectAllocation(dto.ProjectId, dto.EmployeeId, dto.PercentageAllocation);
            
            if (projectAllocation.IsValid())
            {
                await this._projectAllocationService.Add(projectAllocation);
                return CreatedAtAction(nameof(this.Get), new { id = projectAllocation.Id }, projectAllocation);
            }
            return BadRequest();
        }

        /// <summary>
        /// Get Project Allocation By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectAllocation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProjectAllocation), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjectAllocation>> Get(int id)
        {
            var response = await this._projectAllocationService.GetById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Project Allocation by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this._projectAllocationService.Remove(id);
            return NoContent();
        }
    }
}
