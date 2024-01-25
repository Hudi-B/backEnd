using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIv2.Controllers
{
    [ApiController]
    [Route("email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            emailService.SendEmail(request);
            return StatusCode(200, "Email sent.");
        }
    }
}
