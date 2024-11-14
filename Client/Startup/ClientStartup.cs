using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using mdmontesinos.Module.Issue4812.Services;

namespace mdmontesinos.Module.Issue4812.Startup
{
    public class ClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IIssue4812Service, Issue4812Service>();
        }
    }
}
