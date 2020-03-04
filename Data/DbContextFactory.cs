using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    class DbContextFactory : IDesignTimeDbContextFactory<EmailHandlerContext>
    {
        public EmailHandlerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmailHandlerContext>();
            optionsBuilder.UseSqlite("Filename=./emailHandler.db");

            return new EmailHandlerContext(optionsBuilder.Options);
        }
    }
}
