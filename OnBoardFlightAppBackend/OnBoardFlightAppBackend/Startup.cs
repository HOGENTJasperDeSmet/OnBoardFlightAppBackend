using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using On_board_flight_app_backend.Data;
using On_board_flight_app_backend.Data.Repositories;
using On_board_flight_app_backend.Models;

namespace OnBoardFlightAppBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<ILocatieRepository, LocatieRepository>();
            services.AddScoped<IPassagierRepository, PassagierRepository>();
            services.AddScoped<ProjectDataInitializer>();
            services.AddOpenApiDocument(c => {
                c.DocumentName = "apidocs"; c.Title = "FlightAppAPI";
                c.Version = "v1";
                c.Description = "The FlightAppAPI documentation description.";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProjectDataInitializer ProjectDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseSwagger();
            ProjectDataInitializer.InitializeDataAsync().Wait();
        }
    }
}
