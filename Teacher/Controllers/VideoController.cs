using BLL.IService;
using DAL.Models.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        [Authorize(Roles = "Teacher,Admin")]
        [HttpPost("CreateVideo")]
        public async Task<IActionResult> CreateVideo([FromForm]CreateVideo video)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _videoService.CreateVideoAsync(video);
            return Ok(result);
        }
        [Authorize(Roles = "Teacher,Admin")]
        [HttpDelete("DeleteVideo")]
        public async Task<IActionResult> CreateVideo(int videoId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _videoService.DeleteVideoAsync(videoId);
            return Ok(result);
        }
        [HttpGet("GetAllVideosInCheapter")]
        public async Task<IActionResult> GetAllVideosInCheapter(int CheapterId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _videoService.GetAllVideosInCheapter(CheapterId);
            return Ok(result);
        }
        [HttpGet("CreateVideo")]
        public async Task<IActionResult> GetVideo(int videoId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _videoService.GetVideo(videoId);
            return Ok(result);
        }
    }
}
