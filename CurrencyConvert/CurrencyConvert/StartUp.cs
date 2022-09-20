using CurrencyConvert.Repository.Interfaces;
using CurrencyConvert.Repository.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text.Json;
using CurrencyConvert.Context;
using CurrencyConvert.BussinesLogic.Interfaces;
using CurrencyConvert.BussinesLogic.Service;
using AutoMapper;

namespace CurrencyConvertor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IMapper Mapper { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyConverterService, CurrencyConvertorService>();
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<CurrencyConvertorContext>(builder => builder.UseSqlServer(connectionString));
            services.AddControllers();
            services.AddHealthChecks();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseHealthChecks("/health", new HealthCheckOptions { ResponseWriter = JsonResponseWriter });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private async Task JsonResponseWriter(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json";
            await System.Text.Json.JsonSerializer.SerializeAsync(context.Response.Body, new { Status = report.Status.ToString() },
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }).ConfigureAwait(true);
        }
    }
}
