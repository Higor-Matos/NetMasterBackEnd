using NetMaster.Presentation.Configuration;

namespace NetMaster.Presentation.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddlewares(this WebApplication app)
        {
            _ = app.UseCors("AllowAllOrigins");

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            app.UseSwaggerDocumentation();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
