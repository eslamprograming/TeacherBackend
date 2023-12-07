using BLL.IService;
using DAL.Data;
using DAL.Entities;
using DAL.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectTestController : ControllerBase
    {
        private readonly IQuctionTestService _quctionTestService;
        private readonly ApplicationDbContext db;

        public CorrectTestController(IQuctionTestService quctionTestService, ApplicationDbContext db)
        {
            _quctionTestService = quctionTestService;
            this.db = db;
        }
        [HttpPost("CorrectTest2")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> CorrectTest2(List<CorrectQuectionTest> QuestionsTest, int TestId)
        {
            var user = User.FindFirstValue("uid");
            var stId = await db.Students.Where(n => n.ApplicationUserId == user).Select(n=>n.Id).SingleOrDefaultAsync();
            int subId = await db.Tests.Where(n => n.Id==TestId ).Select(n=>n.SubjectId).SingleOrDefaultAsync();

            var result = await _quctionTestService.CorrectTest(QuestionsTest, TestId, stId, subId);
            return Ok(result);
        }
    }
}
