using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using mdmontesinos.Module.Issue4812.Repository;
using mdmontesinos.Module.Issue4812.Services;

namespace mdmontesinos.Module.Issue4812.Startup
{
    public class ServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IIssue4812Service, ServerIssue4812Service>();
            services.AddDbContextFactory<Issue4812Context>(opt => { }, ServiceLifetime.Transient);
        }
    }
}
