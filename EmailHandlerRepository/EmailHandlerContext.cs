using System;
using EmailHandlerRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailHandlerRepository
{
    public class EmailHandlerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./blog.db");
        }
    }
}
