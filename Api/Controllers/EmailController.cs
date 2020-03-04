using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly Lazy<IEmailMessageRepository> _emailMessageRepositoryLazy;

        public EmailController(IEmailMessageRepository emailMessageRepository)
        {
            if(emailMessageRepository is null)
                throw new ArgumentNullException(nameof(emailMessageRepository));

            _emailMessageRepositoryLazy = new Lazy<IEmailMessageRepository>(() => emailMessageRepository);
        }

        [HttpPost]
        [Route(nameof(PostMessage))]
        [ProducesResponseType(typeof(NewEmailMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostMessage([FromBody]NewEmailMessage emailMessage)
        {
            if (emailMessage is null)
                return BadRequest();
            if (!emailMessage.Sender.IsEmail() || emailMessage.ToRecipients.Any(x => !x.IsEmail()))
                return ValidationProblem("One of addresses are not valid email format");
            if (string.IsNullOrEmpty(emailMessage.Subject))
                return ValidationProblem("Subject cannot be empty");

            var emailId = await _emailMessageRepositoryLazy.Value.InsertMessage(emailMessage);
            return Ok(emailId);
        }

        [HttpPost]
        [Route(nameof(UploadAttachment))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UploadAttachment([FromQuery]Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetMessageStatus))]
        [ProducesResponseType(typeof(EmailStatus) ,(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMessageStatus([FromQuery]Guid id)
        {
            var status = await _emailMessageRepositoryLazy.Value.GetStatusById(id);
            return Ok(status);
        }

        [HttpGet]
        [Route(nameof(GetAllMessages))]
        [ProducesResponseType(typeof(List<EmailMessage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMessages()
        {
            var allEmails = await _emailMessageRepositoryLazy.Value.GetAll();
            return Ok(allEmails);
        }
    }
}
