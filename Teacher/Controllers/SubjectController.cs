using BLL.IService;
using DAL.Entities;
using DAL.Models.SubjectModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubjectServiec _subjectServiec;

        public SubjectController(UserManager<ApplicationUser> userManager, ISubjectServiec subjectServiec)
        {
            _userManager = userManager;
            _subjectServiec = subjectServiec;
        }
        [HttpPost("CreateSubject")]
        [Authorize(Roles ="Teacher , Admin")]
        public async Task<IActionResult> CreateSubject([FromForm]CreateSubject subject)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _subjectServiec.CreateSubjectAsync(subject);
            return Ok(result);
        }
        [Authorize(Roles ="Teacher , Admin")]
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int Id)
        {
            var result = await _subjectServiec.DeleteSubjectAaync(Id);
            return Ok(result);
        }
        [HttpGet("Subject")]
        public async Task<IActionResult> Subject(int Id)
        {
            var result= await _subjectServiec.GetSubjectAsync(Id);
            return Ok(result);
        }
        [HttpGet("AllSubject")]
        public async Task<IActionResult> AllSubject()
        {
            var result = await _subjectServiec.GetAllSubjectAsync();
            return Ok(result);
        }
        [Authorize(Roles = "Teacher , Admin")]
        [HttpPatch("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject([FromForm]UpdateSubject subject,int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _subjectServiec.UpdateSubjectAsync(subject, Id);
            return Ok(result);
        }
    }
}
