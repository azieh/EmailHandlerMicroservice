using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IEmailMessageRepository
    {
        Task<Guid> InsertMessageAsync(NewEmailMessage emailMessage);
        Task<List<EmailMessage>> GetAllAsync();
        Task<EmailMessage> GetByIdAsync(Guid id);
        void UpdateStatusToSendById(Guid id);
    }
}
