using BLL.IService;
using DAL.Models.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        //[Authorize(Roles ="Teacher , Admin")]
        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion([FromForm]CreateQuestion question)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result=await _questionService.CreateQuestionAsync(question);
            return Ok(result);
        }
        //[Authorize(Roles = "Teacher , Admin")]
        [HttpDelete("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(int Id)
        {
            var result = await _questionService.DeleteQuestionAsync(Id);
            return Ok(result);
        }
        //[Authorize(Roles = "Teacher , Admin")]
        [HttpPatch("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion([FromForm] CreateQuestion question,int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _questionService.UpdateQuestion(question, Id);
            return Ok(result);
        }
        [HttpGet("AllQuestion")]
        public async Task<IActionResult> AllQuestion(int CheapterId)
        {
            var result = await _questionService.GetAllQuestionsInCheapter(CheapterId);
            return Ok(result);
        }
        [HttpGet("Question")]
        public async Task<IActionResult> Question(int QuestionId)
        {
            var result = await _questionService.GetQuestion(QuestionId);
            return Ok(result);
        }
    }
}
