using AspNetCoreRestaurantApp.Services.Implementation;
using AspNetCoreRestaurantApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreRestaurantApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IRestaurant, Restaurant>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IGreeter greeter,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(greeter.GetMessageOfTheDay());
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "AboutController",
                template: "about/{action}",
                defaults: new { controller = "About", action = "Address" });

            routeBuilder.MapRoute(
                name:"Default",
                template:"{controller=Home}/{action=Index}/{id?}");
        }
    }
}
