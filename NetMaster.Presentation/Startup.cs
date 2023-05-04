using NetMaster.Presentation.Configuration;
using NetMaster.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StreamingServerConfigPresentation>(builder.Configuration.GetSection("StreamingServer"));

builder.Services.AddControllers();

builder.Services.AddScoped<HardwareService>();
builder.Services.AddScoped<SoftwareService>();
builder.Services.AddScoped<SystemService>();
builder.Services.AddScoped<UploadService>();
builder.Services.AddScoped<NetworkService>();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            _ = builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

WebApplication app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.UseSwaggerDocumentation();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
