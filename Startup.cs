using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PentiaExcercise.Repository;
using PentiaExcercise.Service;
using PentiaExcercise.Extensions;
using PentiaExcercise.Context;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace PentiaExcercise
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseDeveloperExceptionPage();
            application.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });

            application.UseMvc(config => {
                config.MapRoute
                (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            application.SeedData();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SiteContext>(options => {
                options.UseSqlite("Filename=./site.db");
            });
            services.AddMvc();

            // Configure dependency injection
            services.AddTransient<ICarPurchaseRepository, CarPurchaseRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISalesPersonRepository, SalesPersonRepository>();
            services.AddTransient<ICarPurchaseService, CarPurchaseService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISalesPersonService, SalesPersonService>();
        }
    }
}