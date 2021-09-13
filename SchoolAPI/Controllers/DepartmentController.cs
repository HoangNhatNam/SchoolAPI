using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Department;
using SchoolAPI.Service;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var department = await _departmentService.GetAll();
            return Ok(department);
        }
        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetById(int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var department = await _departmentService.GetById(departmentId);
            if (department == null)
                return BadRequest();
            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateRequest request)
        {
            // model binding
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // model validation
            if (_departmentService.VerifyName(request.Name))
            {
                return BadRequest($"A department named {request.Name} already exists.");
            }
            // action
            var result = await _departmentService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartmentUpdateRequest request)
        {
            // model binding
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // action
            var result = await _departmentService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> Delete(int departmentId)
        {
            var result = await _departmentService.Delete(departmentId);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
    }
}
