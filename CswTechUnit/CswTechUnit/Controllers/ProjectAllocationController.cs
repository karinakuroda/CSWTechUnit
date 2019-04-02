﻿using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using Domain.Interfaces.Services;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;

namespace CswTechUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAllocationController : ControllerBase
    {
        private readonly IProjectAllocationService _projectAllocationService;

        public ProjectAllocationController(IProjectAllocationService projectAllocationService)
        {
            this._projectAllocationService = projectAllocationService;
        }

        /// <summary>
        /// Add Project Allocation
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectAllocation), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProjectAllocationDTO dto)
        {
            var validation = dto.ProjectId != 0;
            if (validation)
            {
                var projectAllocation = new ProjectAllocation(dto.ProjectId, dto.EmployeeId, dto.PercentageAllocation);
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
        public async Task<ActionResult<ProjectAllocation>> Get(int id)
        {
            return await this._projectAllocationService.GetById(id);
        }

        /// <summary>
        /// Delete Project Allocation by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._projectAllocationService.Remove(id);
        }
    }
}
