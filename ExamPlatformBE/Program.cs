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

// Add Swagger services
builder.Services.AddSwaggerGen(options =>
{
    // You can set the basic API info in Swagger documentation
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Exam Platform API",
        Version = "v1",
        Description = "API for managing exams, users, and more.",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
        }
    });
});

var app = builder.Build();

// Enable Swagger and Swagger UI
app.UseSwagger(); // This enables the Swagger JSON endpoint
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exam Platform API V1"); // Swagger JSON file
    c.RoutePrefix = string.Empty; // Make Swagger UI accessible at the root
});

// Map your endpoints
app.MapUsersEndpoint();

app.MapGet("/", () => "Hello World!");

// Apply migrations on startup
await app.MigrateDbAsync();

app.Run();
