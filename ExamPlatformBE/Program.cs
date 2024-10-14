using ExamPlatformBE.Data;
using ExamPlatformBE.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString =  builder.Configuration.GetConnectionString("ExamPlatform");
builder.Services.AddNpgsql<ExamPlatformContext>(connString);

var app = builder.Build();

app.MapUsersEndpoint();

app.MapGet("/", () => "Hello World!");

await app.MigrateDbAsync(); // this will help to migrateDb everytime we start our app

app.Run();
