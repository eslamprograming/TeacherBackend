using BLL.IService;
using DAL.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;

        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }
        [HttpPost("AddDegree")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> AddDegree(CreateDegree Degree)
        {
            var result = await _degreeService.CreateDegreeAsync(Degree);
            return Ok(result);
        }
        [HttpPost("DeleteDegree")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> DeleteDegree(int DegreeId)
        {
            var result = await _degreeService.DeleteDegreeAsync(DegreeId);
            return Ok(result);
        }
        [HttpGet("GetAllDegreeinTest")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> GetAllDegree(int TestId)
        {
            var result = await _degreeService.GetAllDegreeAsync(TestId);
            return Ok(result);
        }
        [HttpGet("GetStudentDegreesAsync")]
        public async Task<IActionResult> GetStudentDegreesAsync(int StudentId)
        {
            var result = await _degreeService.GetStudentDegreesAsync(StudentId);
            return Ok(result);
        }
        [HttpGet("GetDegree")]
        public async Task<IActionResult> GeTDegree(int StudentId,int TestId)
        {
            var result = await _degreeService.GetDegreeAsync(StudentId,TestId);
            return Ok(result);
        }
    }
}
