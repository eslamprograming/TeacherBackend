using BLL.IService;
using DAL.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTestController : ControllerBase
    {
        private readonly IQuctionTestService _quctionTestService;

        public QuestionTestController(IQuctionTestService quctionTestService)
        {
            _quctionTestService = quctionTestService;
        }
        //[Authorize(Roles ="Teacher , Admin")]
        [HttpPost("CreateQuestionTest")]
        public async Task<IActionResult> CreateQuestionTest([FromForm]CreateQuestionTest questionTest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _quctionTestService.CreateQuctionTestAsync(questionTest);
            return Ok(result);
        }
        //[Authorize(Roles = "Teacher , Admin")]
        [HttpDelete("DeleteQuestionTest")]
        public async Task<IActionResult> DeleteQuestionTest(int QTestId)
        {
            var result = await _quctionTestService.DeleteQuctionTestAsync(QTestId);
            return Ok(result);
        }
        //[Authorize(Roles = "Teacher , Admin")]
        [HttpPatch("UpdateQuestionTest")]
        public async Task<IActionResult> UpdateQuestionTest([FromForm]CreateQuestionTest questionTest,int QTestId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _quctionTestService.UpdateQuctionTest(questionTest,QTestId);
            return Ok(result);
        }
        [HttpGet("GetAllQuestionTest")]
        public async Task<IActionResult> GetAllQuestionTest(int TestId)
        {
            var result = await _quctionTestService.GetAllQuctionTestsInCheapter(TestId);
            return Ok(result);
        }
        [HttpGet("GetQuestionTest")]
        public async Task<IActionResult> GetQuestionTest(int QTestId)
        {
            var result = await _quctionTestService.GetQuctionTest(QTestId);
            return Ok(result);
        }
    }
}
