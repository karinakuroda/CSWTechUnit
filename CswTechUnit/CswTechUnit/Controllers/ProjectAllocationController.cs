using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using Domain.Interfaces.Services;

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
       
        [HttpPost]
        public void Post([FromBody] ProjectAllocationDTO dto)
        {
            this._projectAllocationService.Add(dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._projectAllocationService.Remove(id);
        }
    }
}
