using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<Guid> AddToQueue(NewEmailMessage emailMessage)
        {
            return await _emailMessageRepositoryLazy.Value.InsertMessage(emailMessage);
        }

        public async Task<List<EmailMessage>> GetAll()
        {
           return await _emailMessageRepositoryLazy.Value.GetAll();
        }

        public async Task<EmailMessage> GetById(Guid id)
        {
           return await _emailMessageRepositoryLazy.Value.GetById(id);
        }

        public async Task<EmailStatus> GetStatusById(Guid id)
        {
            var mailDetails = await _emailMessageRepositoryLazy.Value.GetById(id);
            if (mailDetails is null)
                return EmailStatus.None;
            return mailDetails.Status;
        }

        public Task SendEmail(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
