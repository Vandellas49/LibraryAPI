using BL;
using BL.InterFaces;
using BL.Specifications;
using BL.Validator;
using BL.Validator.Filter;
using DAL.Contexts;
using Entities.Dtos;
using Enums;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LibraryAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDBContexts>(_ => _.UseSqlServer(Configuration.GetConnectionString("SQLProvider"), y => y.MigrationsAssembly("DAL")));
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddControllersWithViews(p =>{ p.Filters.Add<ValidationFilter>(); p.Filters.Add<ExceptionCatch>(); }).
            AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).
            ConfigureApiBehaviorOptions(options =>{options.SuppressModelStateInvalidFilter = true;}).
            AddRazorRuntimeCompilation().
            AddFluentValidation();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryDeleteDto>, CategoryDeleteValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<BookAddDto>, BookAddValidator>();
            services.AddTransient<IValidator<BookDeleteDto>, BookDeleteValidator>();
            services.AddTransient<IValidator<BookUpdateDto>, BookUpdateValidator>();
            services.AddTransient<IValidator<PersonAddDto>, PersonAddValidator>();
            services.AddTransient<IValidator<PersonDeleteDto>, PersonDeleteValidator>();
            services.AddTransient<IValidator<PersonDeleteDto>, PersonDeleteValidator>();
            services.AddTransient<IValidator<PersonUpdateDto>, PersonUpdateValidator>();
            services.AddTransient<IValidator<BlockedPersonAddDto>, BlockedPersonAddValidator>();
            services.AddTransient<IValidator<BlockedPersonUpdateDto>, BlockedPersonUpdateValidator>();
            services.AddTransient<IValidator<BookRentAddDto>, BookRentAddValidator>();
            services.AddTransient<IValidator<BookRentDeleteDto>, BookRentDeleteValidator>();
            services.AddTransient<IValidator<BookRentUpdateDto>, BookRentUpdateValidator>();
            services.AddTransient<IValidator<UserDeleteDto>, UserDeleteValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateValidator>();
            services.AddTransient<IValidator<UserAddDto>, UserAddValidator>();
            services.AddTransient<IValidator<UserRoleAddDto>, UserRoleAddValidator>();
            services.AddTransient<IValidator<UserRoleDeleteDto>, UserRoleDeleteValidator>();
            services.AddTransient<IValidator<UserRoleUpdateDto>, UserRoleUpdateValidator>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LibraryAPI",
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            new string[] {}

                    }
                });
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory,"*.xml",SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
            });
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));
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
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole(Role.Admin.ToString()));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryAPI V1");
            });
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
