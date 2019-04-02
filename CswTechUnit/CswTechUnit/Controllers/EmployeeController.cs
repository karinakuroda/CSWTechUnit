using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public async Task<ActionResult<List<Employee>>>Get()
        {
            return await this._employeeService.ListEmployees();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return this._employeeService.GetById(id);
        }
        
        [HttpGet("{id}/projects")]
        public async Task<List<Project>> Projects(int id)
        {
            return await this._employeeService.ListProjectsByEmployeeId(id);
        }

        [HttpPost]
        //[ProducesResponseType] for all possible responses or defaults (I dont know if defaults is already launched)
        //TODO: Use async always when possible
        //TODO: Work with DTO in this layer
        public void Post([FromBody] Employee value)
        {
            this._employeeService.AddEmployee(value);
            //TODO: What kind of return this produces, Created, Accepted, NoContent?
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            this._employeeService.UpdateEmployee(value);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._employeeService.RemoveEmployee(id);
        }
    }
}
