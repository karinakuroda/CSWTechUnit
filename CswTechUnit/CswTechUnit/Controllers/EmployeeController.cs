using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

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
        public async Task<ActionResult<List<Employee>>>Get()
        {
            return await this._employeeService.ListEmployees();
        }

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            return await this._employeeService.GetById(id);
        }

        /// <summary>
        /// List Projects By Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/projects")]
        public async Task<List<Project>> Projects(int id)
        {
            return await this._employeeService.ListProjectsByEmployeeId(id);
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
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
        [ProducesResponseType(typeof(Employee), StatusCodes.Status204NoContent)]
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
        [ProducesResponseType(typeof(Employee), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await this._employeeService.RemoveEmployee(id);
            return NoContent();
        }
    }
}
