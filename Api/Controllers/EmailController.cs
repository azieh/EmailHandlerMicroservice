using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
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
        [ProducesResponseType(typeof(NewEmailMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostMessage([FromBody]NewEmailMessage emailMessage)
        {
            return Ok(emailMessage);
        }

        [HttpPost]
        [Route(nameof(UploadAttachment))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UploadAttachment([FromQuery]Guid id)
        {
            return Ok();
        }

        [HttpGet]
        [Route(nameof(GetMessageStatus))]
        [ProducesResponseType(typeof(EmailStatus) ,(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMessageStatus([FromQuery]Guid id)
        {
            return Ok(true);
        }

        [HttpGet]
        [Route(nameof(GetAllMessages))]
        [ProducesResponseType(typeof(List<EmailMessage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMessages()
        {
            return Ok(new List<EmailMessage>());
        }
    }
}
