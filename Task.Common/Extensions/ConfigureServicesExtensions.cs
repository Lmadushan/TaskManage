using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaskManage.Data;

namespace TaskManage.Common.Extensions
{
    public static class ConfigureServicesExtensions
    {
        private static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IAccessTokenHandler, AccessTokenHandler>();
            
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IClientRepository, ClientRepository>();
            
        }

        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.RegisterRepositories();
            services.RegisterServices();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register Swagger
            services.AddSwaggerDocumentation("Task", "v1");


            return services;
        }

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsProlicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => configuration["AllowedOrgin"].Contains(origin))
                    //.AllowAnyOrigin()
                    .AllowCredentials();
                });
            });
        }

        private static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string apiName, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = apiName, Version = version });
                c.CustomSchemaIds(i => i.FullName);
                //c.AddSecurityDefinition("Bearer",
                //    new OpenApiSecurityScheme
                //    {
                //        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer 12345abcdef\"",
                //        Name = "Authorization",
                //        In = ParameterLocation.Header,
                //        Type = SecuritySchemeType.ApiKey,
                //        Scheme = "Bearer"
                //    }
                //);

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        },
                //        new List<string>()
                //    }
                //});
            });

            return services;
        }
    }
}
