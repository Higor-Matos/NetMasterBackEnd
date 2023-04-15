using NetMaster.Presentation;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StreamingServerConfigPresentation>(builder.Configuration.GetSection("StreamingServer"));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

app.UseSwaggerDocumentation();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
