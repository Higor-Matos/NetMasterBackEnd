using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace NetMaster.Presentation
{
    public static class SwaggerConfigurationPresentation
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NetMaster API",
                    Version = "v1",
                    Description = "A simple API for managing computers in a network",
                    Contact = new OpenApiContact
                    {
                        Name = "Higor Matos",
                        Email = "higordeus22@gmail.com",
                        Url = new System.Uri("https://github.com/Higor-Matos")
                    }
                });
            });
        }

        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetMaster API V1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
