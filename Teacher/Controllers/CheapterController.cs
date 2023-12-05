using BLL.IService;
using DAL.Models.Cheapter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheapterController : ControllerBase
    {
        private readonly ICheapterService _cheapterService;

        public CheapterController(ICheapterService cheapterService)
        {
            _cheapterService = cheapterService;
        }
        [Authorize(Roles ="Teacher , Admin")]
        [HttpPost("CreateCheapter")]
        public async Task<IActionResult> CreateCheapter([FromForm]CreateCheapter cheapter)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _cheapterService.CreateCheapterAsync(cheapter);
            return Ok(result);
        }
        [Authorize(Roles = "Teacher , Admin")]
        [HttpDelete("DeleteCheapter")]
        public async Task<IActionResult> DeleteCheapter(int CheapterId)
        {
            var result = await _cheapterService.DeleteCheapterAsync(CheapterId);
            return Ok(result);
        }
        [Authorize(Roles = "Teacher , Admin")]
        [HttpPatch("UpdateCheapter")]
        public async Task<IActionResult> UpdateCheapter([FromForm]CreateCheapter cheapter,int cheapterId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _cheapterService.UpdateCheapter(cheapter, cheapterId);
            return Ok(result);
        }
        [HttpGet("GetAllCheapter")]
        public async Task<IActionResult> GetAllCheapter(int subjectId)
        {
            var result = await _cheapterService.GetAllCheaptersInSubject(subjectId);
            return Ok(result);
        }
        [HttpGet("GetCheapter")]
        public async Task<IActionResult> GetCheapter(int cheapterId)
        {
            var result = await _cheapterService.GetCheapter(cheapterId);
            return Ok(result);
        }
    }
}
