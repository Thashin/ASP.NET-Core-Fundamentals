using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //This is a place to register services for dependency injection
        public void ConfigureServices(IServiceCollection services)
        {
            //The service you want to provide and how to instantiate the object
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurant>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Configures the http processing pipeline, for every request this defines how to respond to that request
        //The parameters in this method is a type of dependency injection. ASP.NET use the parameters and will pass in an
        //object or service that implements those interfaces
        //This is where all the middleware is stored
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //If there are no arguments in this call the order of middleware matters in this case
            //as the useWelcomepage middleware responds to every request any
            //middleware underneath it becomes unreachable
            //app.UseWelcomePage( new WelcomePageOptions
            //{
            //    Path="/wp"
            //});

            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
