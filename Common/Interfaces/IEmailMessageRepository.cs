using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IEmailMessageRepository
    {
        void InsertMessage();
        void UpdateMessage();
        List<EmailMessage> GetAll();
        List<EmailMessage> GetById(Guid id);
        EmailStatus GetStatusById(Guid id);
        EmailStatus UpdateStatusById(Guid id);
    }
}
