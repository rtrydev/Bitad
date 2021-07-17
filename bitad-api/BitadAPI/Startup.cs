using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using BitadAPI.Repositories;
using BitadAPI.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using BitadAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            var context = new RepositoryContext();
            context.Database.Migrate();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddAuthentication(options => options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secretstringverysecure")),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                    }
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<RepositoryContext>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAgendaRepository, AgendaRepository>();
            services.AddTransient<IWorkshopRepository, WorkshopRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<IQrCodeRedeemRepository, QrCodeRedeemRepository>();
            services.AddTransient<IQrCodeRepository, QrCodeRepository>();
            services.AddTransient<ISponsorRepository, SponsorRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkshopService, WorkshopService>();
            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IQrCodeRedeemService, QrCodeRedeemService>();
            services.AddScoped<ISponsorService, SponsorService>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api");
                c.RoutePrefix = String.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod())
                .Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
