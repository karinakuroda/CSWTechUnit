using System.Collections.Generic;
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
       
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Project value)
        {
            _projectService.Add(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectService.Remove(id);
        }
    }
}
