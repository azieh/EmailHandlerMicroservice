﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IEmailMessageRepository
    {
        Task<Guid> InsertMessage(NewEmailMessage emailMessage);
        Task<List<EmailMessage>> GetAll();
        Task<EmailMessage> GetById(Guid id);
        void UpdateStatusToSendById(Guid id);
    }
}
