using Microsoft.EntityFrameworkCore;
using RentACarApi.Cors;
using RentACarApi.Data;
using RentACarApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Configuring the database
string connectionString = builder.Configuration.GetConnectionString("MainDatabase") ?? string.Empty;
if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("No connection string found.");
    return;
}

// Configuring CORS
builder.Services.SetupCors(builder.Configuration);

builder.Services.AddMySql<RentACarContext>(connectionString, new MariaDbServerVersion(new Version(11, 6, 2)));

var app = builder.Build();

app.UseCors();
app.UseStaticFiles();

app.MapManufacturerEndpoints();
app.MapFuelTypeEndpoints();
app.MapCategoryEndpoints();
app.MapModelEndpoints();
app.MapCarEndpoints();
app.MapImageEndpoints();
app.MapSupportMessageEndpoints();

app.Run();