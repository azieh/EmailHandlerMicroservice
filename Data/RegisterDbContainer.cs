using Common.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class RegisterDbContainer
    {
        public static void ConfigureServices(IServiceCollection services, string dbLocation)
        {
            services.AddDbContext<EmailHandlerContext>(options =>
                options.UseSqlite(dbLocation));
        }

        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEmailMessageRepository, EmailMessageRepository>();
        }

    }
}
