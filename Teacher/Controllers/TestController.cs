
using BLL.Helper;
using BLL.IService;
using DAL.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        //[Authorize(Roles ="Teacher , Admin")]
        [HttpPost("CreateTest")]
        public async Task<IActionResult> CreateTest([FromForm]CreateTest test)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _testService.CreateTestAsync(test);
            return Ok(result);
        }
        //[Authorize(Roles = "Teacher , Admin")]
        [HttpDelete("DeleteTest")]
        public async Task<IActionResult> DeleteTest(int testId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _testService.DeleteTestAsync(testId);
            return Ok(result);
        }
        //[Authorize(Roles = "Teacher , Admin")]
        [HttpPatch("UpdateTest")]
        public async Task<IActionResult> UpdateTest([FromForm]CreateTest test,int TestId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _testService.UpdateTest(test,TestId);
            return Ok(result);
        }
        [HttpGet("GetAllTestInSubject")]
        public async Task<IActionResult> GetAllTestInSubject(int SubjectId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _testService.GetAllTestsInSubject(SubjectId);
            return Ok(result);
        }
        [HttpGet("GetTest")]
        public async Task<IActionResult> GetTest(int TestId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _testService.GetTest(TestId);
            return Ok(result);
        }
    }
}
