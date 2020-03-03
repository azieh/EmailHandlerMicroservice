using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmailHandlerRepository
{
    public static class RegisterDbContainer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmailHandlerContext>(options =>
                options.UseSqlite("Filename=./emailHandler.db"));
        }
    }
}
