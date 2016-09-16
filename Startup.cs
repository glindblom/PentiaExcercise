using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PentiaExcercise
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseDeveloperExceptionPage();

            application.UseMvc(config => {
                config.MapRoute
                (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}