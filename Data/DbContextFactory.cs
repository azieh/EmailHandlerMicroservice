using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<EmailHandlerContext>
    {
        public EmailHandlerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmailHandlerContext>();
            optionsBuilder.UseSqlite("Filename=./emailHandler.db");

            return new EmailHandlerContext(optionsBuilder.Options);
        }
    }
}