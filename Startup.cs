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
            // Enable developer exception pages to print information on error 500's
            application.UseDeveloperExceptionPage();

            // Enable static files with a physical file provider so we can use local script-
            // and css-files
            application.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });

            // Configure the application to use MVC with a basic route-setup
            application.UseMvc(config => {
                config.MapRoute
                (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            // Seed the database with test data if no data is present
            application.SeedData();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Use Sqlite for the ease of setup and speed of development
            services.AddDbContext<SiteContext>(options => {
                options.UseSqlite("Filename=./site.db");
            });

            // Add MVC as a service. Kind of important if I want the rest
            // of the application to work.
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