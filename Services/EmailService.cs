using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Common.Models;

namespace Services
{
    public class EmailService : IEmailService
    {
        private readonly Lazy<IEmailMessageRepository> _emailMessageRepositoryLazy;
        private readonly Lazy<ISmtpService> _smtpServiceLazy;

        public EmailService(IEmailMessageRepository emailMessageRepository, ISmtpService smtpService)
        {
            if (emailMessageRepository is null)
                throw new ArgumentNullException(nameof(emailMessageRepository));
            if (smtpService is null)
                throw new ArgumentNullException(nameof(smtpService));

            _emailMessageRepositoryLazy = new Lazy<IEmailMessageRepository>(() => emailMessageRepository);
            _smtpServiceLazy = new Lazy<ISmtpService>(() => smtpService);
        }

        public async Task<Guid> AddToQueueAsync(NewEmailMessage emailMessage)
        {
            return await _emailMessageRepositoryLazy.Value.InsertMessageAsync(emailMessage);
        }

        public async Task<List<EmailMessage>> GetAllAsync()
        {
            return await _emailMessageRepositoryLazy.Value.GetAllAsync();
        }

        public async Task<EmailMessage> GetByIdAsync(Guid id)
        {
            return await _emailMessageRepositoryLazy.Value.GetByIdAsync(id);
        }

        public async Task<EmailStatus> GetStatusByIdAsync(Guid id)
        {
            var mailDetails = await _emailMessageRepositoryLazy.Value.GetByIdAsync(id);
            if (mailDetails is null)
                return EmailStatus.None;
            return mailDetails.Status;
        }

        public async Task<List<Guid>> SendAllPendingEmailsAsync()
        {
            List<Guid> sendedEmailsIds = new List<Guid>();
            List<EmailMessage> pendingEmailIds = await _emailMessageRepositoryLazy.Value.GetAllPendingAsync();
            foreach (var email in pendingEmailIds)
            {
                try
                {
                    await _smtpServiceLazy.Value.SendEmailAsync(email);
                    _emailMessageRepositoryLazy.Value.UpdateStatusToSendById(email.Id);
                    sendedEmailsIds.Add(email.Id);
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
                
            }

            return sendedEmailsIds;
        }
    }
}