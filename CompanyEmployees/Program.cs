using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

namespace CompanyEmployees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // Add services to the container.

            //Services -DEPENDENCY INJECTION//////////////
            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLoggerService();
            builder.Services.AddControllers();



            //Middleware - PIPELINES//////////////////////
            var app = builder.Build();
            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
                //TODO:What is HSTS?
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //TODO: Research what is UseForwadedHeaders midlWare
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}