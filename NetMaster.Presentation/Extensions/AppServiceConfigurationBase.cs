namespace NetMaster.Presentation.Extensions
{
    public abstract class AppServiceConfigurationBase
    {
        protected readonly IServiceCollection _services;
        protected readonly WebApplicationBuilder _builder;

        protected AppServiceConfigurationBase(IServiceCollection services, WebApplicationBuilder builder)
        {
            _services = services;
            _builder = builder;
        }

        public abstract void ConfigureServices();
    }
}
