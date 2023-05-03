using Microsoft.OpenApi.Models;

namespace NetMaster.Presentation.Configuration
{
    public static class SwaggerConfigurationPresentation
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            _ = services.AddSwaggerGen(c =>
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
                        Url = new Uri("https://github.com/Higor-Matos")
                    }
                });
            });
        }

        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetMaster API V1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
