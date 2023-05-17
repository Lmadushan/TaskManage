using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaskManage.Core.Repositories;
using TaskManage.Core.Services;
using TaskManage.Data;
using TaskManage.Repositories;
using TaskManage.Services;

namespace TaskManage.Common.Extensions
{
    public static class ConfigureServicesExtensions
    {
        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();

        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

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
            });

            return services;
        }
    }
}
