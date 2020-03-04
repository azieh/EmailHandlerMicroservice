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
    /// <summary>
    ///     Actions available for EmailHandler
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly Lazy<IEmailService> _emailServiceLazy;

        public EmailController(IEmailService emailService)
        {
            if (emailService is null)
                throw new ArgumentNullException(nameof(emailService));

            _emailServiceLazy = new Lazy<IEmailService>(() => emailService);
        }

        /// <summary>
        ///     Add email to queue
        /// </summary>
        /// <returns><see cref="Guid"/>Id of created email</returns>
        [HttpPut]
        [Route("Add")]
        [ProducesResponseType(typeof(Guid), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> PutMessage([FromBody] NewEmailMessage emailMessage)
        {
            var emailId = await _emailServiceLazy.Value.AddToQueueAsync(emailMessage);
            return Ok(emailId);
        }

        /// <summary>
        ///     Provides detailed description about email
        /// </summary>
        /// <param name="id">Email Id</param>
        /// <returns><see cref="EmailMessage"/></returns>
        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(typeof(EmailMessage), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetMessageDetails([FromQuery] Guid id)
        {
            var email = await _emailServiceLazy.Value.GetByIdAsync(id);
            if (email is null)
                return NotFound();

            return Ok(email);
        }

        /// <summary>
        ///     Provides status of email
        /// </summary>
        /// <param name="id">Email Id</param>
        /// <returns><see cref="EmailStatus"/></returns>
        [HttpGet]
        [Route("Status")]
        [ProducesResponseType(typeof(EmailStatus), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetMessageStatus([FromQuery] Guid id)
        {
            var status = await _emailServiceLazy.Value.GetStatusByIdAsync(id);
            if (status == EmailStatus.None)
                return NotFound();

            return Ok(status);
        }

        /// <summary>
        ///     Provides detailed description about all email in database
        /// </summary>
        /// <returns>Return list of all emails</returns>
        [HttpGet]
        [Route("All")]
        [ProducesResponseType(typeof(List<EmailMessage>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMessages()
        {
            var allEmails = await _emailServiceLazy.Value.GetAllAsync();
            return Ok(allEmails);
        }

        /// <summary>
        ///     Send all emails in PENDING status
        /// </summary>
        /// <returns>Return list of all sended emails</returns>
        [HttpPost]
        [Route("Send")]
        [ProducesResponseType(typeof(List<Guid>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> SendAllPendingEmails()
        {
            var allEmails = await _emailServiceLazy.Value.SendAllPendingEmailsAsync();
            return Ok(allEmails);
        }
    }
}