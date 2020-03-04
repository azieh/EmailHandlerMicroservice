using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IEmailService
    {
        Task<Guid> AddToQueueAsync(NewEmailMessage emailMessage);
        Task<List<EmailMessage>> GetAllAsync();
        Task<EmailMessage> GetByIdAsync(Guid id);
        Task<EmailStatus> GetStatusByIdAsync(Guid id);
        Task<List<Guid>> SendAllPendingEmailsAsync();
    }
}