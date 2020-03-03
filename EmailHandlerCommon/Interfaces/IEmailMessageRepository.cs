using System;
using System.Collections.Generic;
using System.Text;
using EmailHandlerApi.Models;
using EmailHandlerCommon.Enums;

namespace EmailHandlerCommon.Interfaces
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
