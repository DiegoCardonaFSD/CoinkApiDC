
using CoinkApiDC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
var db = Environment.GetEnvironmentVariable("POSTGRES_DB");
var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";

Console.WriteLine($"Connecting to database with: {connectionString}");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
);
// Register services
builder.Services.AddScoped<ICountryService, GeographyService>();
builder.Services.AddScoped<IDepartmentService, GeographyService>();
builder.Services.AddScoped<ICityService, GeographyService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Controllers
app.MapControllers();

app.Run();