using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employeeService.ListEmployees();
        }

       
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return _employeeService.GetById(id);
        }


        [HttpGet("{id}/projects")]
        public async Task<IQueryable<Project>> Projects(int id)
        {
            return await _employeeService.ListProjectsByEmployeeId(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            _employeeService.AddEmployee(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            _employeeService.UpdateEmployee(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.RemoveEmployee(id);
        }
    }
}
