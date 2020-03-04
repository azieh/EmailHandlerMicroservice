using Data;
using Microsoft.Extensions.DependencyInjection;

namespace Api.ProjectSetup
{
    public static class RegisterContainers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            RegisterDbContainer.Register(services);
        }
    }
}