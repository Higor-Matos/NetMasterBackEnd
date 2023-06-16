//NetMaster.Presentation/Startup.cs
using NetMaster.Domain.Configurations;
using NetMaster.Infrastructure.Context;
using NetMaster.Presentation.Configuration;
using NetMaster.Presentation.Extensions;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add configurations
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.Configure<StreamingServerConfigPresentation>(builder.Configuration.GetSection("StreamingServer"));

// Add database context
builder.Services.AddSingleton<MongoDbContext>(provider =>
{
    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
    MongoDbSettings? mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    string connectionString = mongoDbSettings?.ConnectionString ?? throw new ArgumentException("ConnectionString in MongoDbSettings is required.");
    string databaseName = mongoDbSettings?.DatabaseName ?? throw new ArgumentException("DatabaseName in MongoDbSettings is required.");
    return new MongoDbContext(connectionString, databaseName);
});


// Add services and repositories from assembly
builder.Services.AddServicesInAssembly();


// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            _ = builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

WebApplication app = builder.Build();

// Use CORS
app.UseCors("AllowAllOrigins");

// Use routing
app.UseRouting();

// Use authorization
app.UseAuthorization();

// Use Swagger documentation
app.UseSwaggerDocumentation();

// Map controllers
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
