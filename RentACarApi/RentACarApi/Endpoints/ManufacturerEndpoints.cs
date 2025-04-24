using Microsoft.EntityFrameworkCore;
using RentACarApi.Authentication;
using RentACarApi.Cors;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;

namespace RentACarApi.Endpoints;

public static class ManufacturerEndpoints
{
    public static WebApplication MapManufacturerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/manufacturers");

        group.MapGet("/", (RentACarContext db) => {
            return Results.Ok(db.Manufacturers.ToList());
        })
        .RequireCors(CorsHelper.AllowAllOrigins);
        
        group.MapGet("/{id:int}", (RentACarContext db, int id) => {
            Manufacturer? manufacturer = db.Manufacturers.FirstOrDefault(x => x.Id == id);
            
            if(manufacturer == null)
                return Results.NotFound();
            
            return Results.Ok(manufacturer);
        })
        .RequireCors(CorsHelper.AllowAllOrigins);

        group.MapPost("/", (RentACarContext db, CreateManufacturerDto dto) => {
            Manufacturer manufacturer = new Manufacturer { Name = dto.Name };
            
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            return Results.Created($"/{manufacturer.Id}", manufacturer);
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();
        
        group.MapPut("/{id:int}", (RentACarContext db, int id, UpdateManufacturerDto dto) => {
            Manufacturer? manufacturer = db.Manufacturers.Find(id);

            if (manufacturer is null)
            {
                return Results.NotFound();
            }
            
            db.Entry(manufacturer)
                .CurrentValues
                .SetValues(new Manufacturer{ Id = id, Name = dto.Name });
            db.SaveChanges();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();
        
        group.MapDelete("/{id:int}", (RentACarContext db, int id) => {
            db.Manufacturers.Where(x => x.Id == id)
                .ExecuteDelete();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();
        
        return app;
    }
}