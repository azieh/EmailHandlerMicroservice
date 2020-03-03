using EmailHandlerRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailHandlerRepository
{
    public class EmailHandlerContext : DbContext
    {
        public EmailHandlerContext(DbContextOptions<EmailHandlerContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }

    }
}
