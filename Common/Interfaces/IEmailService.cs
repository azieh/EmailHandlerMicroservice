using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IEmailService
    {
        Task<Guid> AddToQueue(NewEmailMessage emailMessage);
        Task<List<EmailMessage>> GetAll();
        Task<EmailMessage> GetById(Guid id);
        Task<EmailStatus> GetStatusById(Guid id);
        Task SendEmail(Guid id);
    }
}