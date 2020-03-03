using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailHandlerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmailHandlerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {

        public EmailController()
        {
        }

        [HttpPost]
        [Route(nameof(PostMessage))]
        public async Task<IActionResult> PostMessage([FromQuery]EmailMessage emailMessage)
        {
            return Ok(emailMessage);
        }

        [HttpPost]
        [Route(nameof(UploadAttachment))]
        public async Task<IActionResult> UploadAttachment([FromQuery]Guid id)
        {
            return Ok();
        }

        [HttpGet]
        [Route(nameof(GetMessageStatus))]
        public async Task<IActionResult> GetMessageStatus([FromQuery]Guid id)
        {
            return Ok(true);
        }

        [HttpGet]
        [Route(nameof(GetAllMessages))]
        public async Task<IActionResult> GetAllMessages()
        {
            return Ok(new List<EmailMessage>());
        }
    }
}
