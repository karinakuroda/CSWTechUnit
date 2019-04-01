﻿using System.Collections.Generic;
using Domain;
using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
       
        // POST api/values
        [HttpPost]
        public void Post([FromBody] ProjectAllocationDTO dto)
        {
            _projectAllocationService.Add(dto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectAllocationService.Remove(id);
        }
    }
}
