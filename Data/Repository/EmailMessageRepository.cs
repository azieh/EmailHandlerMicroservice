﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EmailMessageRepository : IEmailMessageRepository
    {
        private readonly Lazy<EmailHandlerContext> _dbContext;

        public EmailMessageRepository(EmailHandlerContext dbContext)
        {
            if(dbContext is null)
                throw new ArgumentNullException(nameof(dbContext));

            _dbContext = new Lazy<EmailHandlerContext>(() => dbContext);
        }
        public async Task<List<EmailMessage>> GetAll()
        {
            return await _dbContext.Value.EmailMessages.Select(x => x.MapToDto()).ToListAsync();
        }

        public async Task<EmailMessage> GetById(Guid id)
        {
            var entity = await _dbContext.Value.EmailMessages.FirstOrDefaultAsync(x => x.Id == id);
            return entity.MapToDto();
        }

        public async Task<EmailStatus> GetStatusById(Guid id)
        {
            var entity = await _dbContext.Value.EmailMessages.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
                throw new KeyNotFoundException(id.ToString());
            return (EmailStatus)entity.Status;
        }

        public async Task<Guid> InsertMessage(NewEmailMessage newEmailMessage)
        {
            var entity = newEmailMessage.MapFromNewDto();
            _dbContext.Value.EmailMessages.Add(entity);
            await _dbContext.Value.SaveChangesAsync();
            return entity.Id;
        }

        public Task UpdateMessage()
        {
            throw new NotImplementedException();
        }

        public void UpdateStatusToSendById(Guid id)
        {
            _dbContext.Value.EmailMessages.Update(new Models.EmailMessage{Id = id, Status = (int)EmailStatus.Send});
        }
    }
}
