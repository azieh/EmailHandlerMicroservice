using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public sealed class EmailHandlerContext : DbContext
    {
        private static readonly bool[] Migrated = {false};

        public EmailHandlerContext(DbContextOptions<EmailHandlerContext> options) : base(options)
        {
            if (!Migrated[0])
                lock (Migrated)
                {
                    if (!Migrated[0])
                    {
                        Database.Migrate(); // apply all migrations
                        Migrated[0] = true;
                    }
                }
        }

        public DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./emailHandler.db");
        }
    }
}