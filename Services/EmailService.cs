using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Common.Models;

namespace Services
{
    public class EmailService : IEmailService
    {
        private readonly Lazy<IEmailMessageRepository> _emailMessageRepositoryLazy;

        public EmailService(IEmailMessageRepository emailMessageRepository)
        {
            if (emailMessageRepository is null)
                throw new ArgumentNullException(nameof(emailMessageRepository));

            _emailMessageRepositoryLazy = new Lazy<IEmailMessageRepository>(() => emailMessageRepository);
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

        public Task<List<Guid>> SendAllPendingEmailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}