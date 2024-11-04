using dotenv.net;
using ExamPlatformBE.Data;
using ExamPlatformBE.Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

// Get the connection string from environment variables
var connString = Environment.GetEnvironmentVariable("ExamPlatformDb");

// If the connection string is not found, throw an exception
if (string.IsNullOrEmpty(connString))
{
    throw new Exception("Connection string for 'ExamPlatform' not found in environment variables.");
}

// Add the PostgreSQL service with connection string
builder.Services.AddNpgsql<ExamPlatformContext>(connString);


builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
// Add Swagger services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API documentation"
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exam Platform API v1");
    c.RoutePrefix = string.Empty;  // Makes Swagger UI available at the root of the app
});  // Configure Swagger UI


// Map your endpoints
app.MapUsersEndpoint();
app.MapExamsEndpoint();
app.MapQuestionsEndpoint();

// app.MapGet("/", () => "Hello World One!");

// Apply migrations on startup
await app.MigrateDbAsync();

app.Run();
