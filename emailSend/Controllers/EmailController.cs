using emailSend.Models.DTOs;
using emailSend.Service.IEmailServices;
using Microsoft.AspNetCore.Mvc;

namespace emailSend.Controllers
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
