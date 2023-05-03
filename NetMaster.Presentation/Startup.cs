using NetMaster.Presentation.Configuration;
using NetMaster.Services;
using NetMaster.Services.Powershell;
using NetMaster.Services.Powershell.PowershellServices;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StreamingServerConfigPresentation>(builder.Configuration.GetSection("StreamingServer"));

builder.Services.AddControllers();

builder.Services.AddScoped<HardwareService>();
builder.Services.AddScoped<SoftwareService>();
builder.Services.AddScoped<SystemService>();
builder.Services.AddScoped<UploadService>();
builder.Services.AddScoped<PowershellService>();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            _ = builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

WebApplication app = builder.Build();

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.UseSwaggerDocumentation();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
