using System;
using System.Collections.Generic;
using System.Text;
using EmailHandlerApi.Models;
using EmailHandlerCommon.Enums;
using EmailHandlerCommon.Interfaces;

namespace EmailHandlerRepository.Repository
{
    public class EmailMessageRepository : IEmailMessageRepository
    {
        public List<EmailMessage> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<EmailMessage> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public EmailStatus GetStatusById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void InsertMessage()
        {
            throw new NotImplementedException();
        }

        public void UpdateMessage()
        {
            throw new NotImplementedException();
        }

        public EmailStatus UpdateStatusById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
