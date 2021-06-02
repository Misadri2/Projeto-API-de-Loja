
using desafio_gft_api.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace desafio_gft_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailService _emailService = null;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public bool SendEmail(EmailData emailData)
        {
            return _emailService.SendEmail(emailData);
        }
    }
}