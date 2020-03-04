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
        private readonly Lazy<IEmailService> _emailServiceLazy;

        public EmailController(IEmailService emailService)
        {
            if(emailService is null)
                throw new ArgumentNullException(nameof(emailService));

            _emailServiceLazy = new Lazy<IEmailService>(() => emailService);
        }

        [HttpPut]
        [Route(nameof(PutMessage))]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutMessage([FromBody]NewEmailMessage emailMessage)
        {
            var emailId = await _emailServiceLazy.Value.AddToQueueAsync(emailMessage);
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
        [Route(nameof(GetMessageDetails))]
        [ProducesResponseType(typeof(EmailStatus), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMessageDetails([FromQuery]Guid id)
        {
            var status = await _emailServiceLazy.Value.GetByIdAsync(id);
            if (status is null)
                return NotFound();

            return Ok(status);
        }

        [HttpGet]
        [Route(nameof(GetMessageStatus))]
        [ProducesResponseType(typeof(EmailStatus) ,(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMessageStatus([FromQuery]Guid id)
        {
            var status = await _emailServiceLazy.Value.GetStatusByIdAsync(id);
            if (status == EmailStatus.None)
                return NotFound();

            return Ok(status);
        }

        [HttpGet]
        [Route(nameof(GetAllMessages))]
        [ProducesResponseType(typeof(List<EmailMessage>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMessages()
        {
            var allEmails = await _emailServiceLazy.Value.GetAllAsync();
            return Ok(allEmails);
        }

        [HttpPost]
        [Route(nameof(GetAllMessages))]
        [ProducesResponseType(typeof(List<Guid>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendAllPendingEmails()
        {
            var allEmails = await _emailServiceLazy.Value.SendAllPendingEmailsAsync();
            return Ok(allEmails);
        }
    }
}
