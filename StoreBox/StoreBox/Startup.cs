using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StoreBox.Config;
using StoreBox.Controller;
using StoreBox.Controllers;
using StoreBox.Entities;
using StoreBox.Entities.Models;
using StoreBox.Repository;
using StoreBox.Service;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace StoreBox
{
    public class Startup
    {
        readonly string CORSOpenPolicy = "OpenCORSPolicy";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => {
                options.AddPolicy(
                      name: CORSOpenPolicy,
                      builder => {
                          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
            });

            services.AddDbContext<StoreBoxDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ConfigContext")));

            //services.AddDbContext<StoreBoxDBContext>(opt => opt.UseInMemoryDatabase("StoreBoxDB"));

            services.AddScoped<ValidationFilterAttribute>();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreBox", Version = "v1" });
            });

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            

            services.AddSingleton(Configuration.GetSection("Configuration").Get<StoreBoxConfiguration>());
            services.AddMemoryCache();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreBox v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(CORSOpenPolicy);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    
                    context.Response.ContentType = Text.Plain;

                    await context.Response.WriteAsync("An exception was thrown.");

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Path == "/")
                    {
                        await context.Response.WriteAsync(" Page: Home.");
                    }
                });
            });
            PrepDb.PrepPopulation(app);
        }
    }
}
