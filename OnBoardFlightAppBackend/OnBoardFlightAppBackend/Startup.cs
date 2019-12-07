using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using On_board_flight_app_backend.Data;
using On_board_flight_app_backend.Data.Repositories;
using On_board_flight_app_backend.Models;
using On_board_flight_app_backend.Models.Repositories;
using OnBoardFlightAppBackend.Data.Repositories;
using OnBoardFlightAppBackend.Models.Repositories;

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
            services.AddScoped<IBestellingRepository, BestellingRepository>();
            services.AddScoped<IGroepsChatRepository, GroepsChatRepository>();
            services.AddScoped<ProjectDataInitializer>();

            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Windows API";
                c.Version = "v1";
                c.Description = "De API documentatie van de vluchtApp van windows 2019";
                c.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token", new OpenApiSecurityScheme
                {

                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer' + valid JWT token into field"
                }));
                c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
            });

            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(cfg => cfg.User.RequireUniqueEmail = true).AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Personeel", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });

                options.AddPolicy("Passagier", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   RequireExpirationTime = false,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));

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
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseOpenApi();
            ProjectDataInitializer.InitializeDataAsync().Wait();
        }
    }
}
