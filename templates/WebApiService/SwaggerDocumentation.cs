using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApiService
{
    internal static class SwaggerDocumentation
    {
        internal static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "WebApiService",
                    Version = "v1.0",
                    Description = "WebApiService"
                });

                options.CustomSchemaIds(SchemaIdStrategy);
            });
        }

        internal static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "WebApiService V1.0");
            });
        }

        private static string SchemaIdStrategy(Type currentClass)
        {
            string className = currentClass.Name;
            if (className.EndsWith("Dto"))
            {
                className = className.Remove(className.Length - 3, 3);
            }

            return className;
        }
    }
}
