using System;
using System.Net;
using System.Net.Mail;
using Common.Interfaces;
using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Api.ProjectSetup
{
    public static class RegisterContainers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            RegisterDbContainer.Register(services);
            RegisterSmtp(services);
            services.AddScoped<ISmtpService, SmtpService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        public static void RegisterSmtp(IServiceCollection service)
        {
            service.AddTransient(serviceProvider =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient
                {
                    Host = config.GetValue<string>("Settings:Smtp:Host"),
                    Port = config.GetValue<int>("Settings:Smtp:Port"),
                    Credentials = new NetworkCredential(
                        config.GetValue<string>("Settings:Smtp:Username"),
                        config.GetValue<string>("Settings:Smtp:Password")
                    )
                };
            });
        }
    }
}