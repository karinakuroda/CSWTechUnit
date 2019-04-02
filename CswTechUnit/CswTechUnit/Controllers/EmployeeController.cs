﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain;
using Domain.Interfaces.Services;

namespace CswTechUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        
        /// <summary>
        /// List Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Employee>>>Get()
        {
            var response = await this._employeeService.ListEmployees();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var response = await this._employeeService.GetById(id);
            if (response!=null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// List Projects By Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/projects")]
        [ProducesResponseType(typeof(List<Project>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Project>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Project>>> Projects(int id)
        {
            var response = await this._employeeService.ListProjectsByEmployeeId(id);
            if (response.Count>0)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var validation = employee.Name != "";
            if (validation)
            {
                await this._employeeService.AddEmployee(employee);
                return CreatedAtAction(nameof(this.Get), new { id = employee.Id }, employee);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee"></param>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            var validation = employee.Name != "";
            if (validation)
            {
                await this._employeeService.UpdateEmployee(employee);
                return NoContent();
            }
            return BadRequest();
        }
        
        /// <summary>
        /// Delete Employee by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this._employeeService.RemoveEmployee(id);
            return NoContent();
        }
    }
}
