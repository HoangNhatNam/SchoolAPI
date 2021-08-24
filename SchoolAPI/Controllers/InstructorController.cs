using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SchoolAPI.Models.Instructor;
using SchoolAPI.Service;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _instructorService.GetAll();
            return Ok(instructors);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging(string sortOrder, string keyword, int pageIndex,
            int pageSize)
        {
            var instructors = await _instructorService.GetAllPaging(sortOrder, keyword, pageIndex, pageSize);
            return Ok(instructors);
        }
        [HttpGet("{instructorId}")]
        public async Task<IActionResult> GetById(int instructorId)
        {
            var instructor = await _instructorService.GetById(instructorId);
            if (instructor == null)
                return BadRequest();
            return Ok(instructor);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]InstructorCreateRequest request)
        {
            var result = await _instructorService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] InstructorUpdateRequest request)
        {
            var result = await _instructorService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{instructorId}")]
        public async Task<IActionResult> Delete(int instructorId)
        {
            var result = await _instructorService.Delete(instructorId);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
    }
}
