
using BLL.Helper;
using BLL.IService;
using DAL.Models.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISendMailService sendMailService;

        public TestController(ISendMailService sendMailService)
        {
            this.sendMailService = sendMailService;
        }

        [HttpPost("sendMail")]
        public async Task<IActionResult> sendMail()
        {
            var result = sendMailService.sendEmailAsync("eslam.alsayed.khalil@gmail.com", "subject", "body");
            return Ok("send");
        }
        [HttpPost("Uploadphoto")]
        public  IActionResult Uploadphoto([FromForm] photo FileName)
        {
            var result = BLL.Helper.Files.Save(FileName.image);
            return Ok(result);
        }
    }
}
