using Microsoft.EntityFrameworkCore;
using RentACarApi.Authentication;
using RentACarApi.Cors;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;

namespace RentACarApi.Endpoints;

public static class FuelTypeEndpoints
{
    public static WebApplication MapFuelTypeEndpoints(this WebApplication app)
    {
        
        var group = app.MapGroup("/fuel_types");

        group.MapGet("/", (RentACarContext db) => {
            return Results.Ok(db.FuelTypes.ToList());
        })
        .RequireCors(CorsHelper.AllowAllOrigins);
        
        group.MapGet("/{id:int}", (RentACarContext db, int id) => {
            FuelType? fuel = db.FuelTypes.FirstOrDefault(x => x.Id == id);
            
            if(fuel == null)
                return Results.NotFound();
            
            return Results.Ok(fuel);
        })
        .RequireCors(CorsHelper.AllowAllOrigins);

        group.MapPost("/", (RentACarContext db, CreateFuelTypeDto dto) => {
            FuelType fuel = new FuelType{Name = dto.Name};
            
            db.FuelTypes.Add(fuel);
            db.SaveChanges();

            return Results.Created($"/{fuel.Id}", fuel);
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();
        
        group.MapPut("/{id:int}", (RentACarContext db, int id, UpdateFuelTypeDto dto) => {
            FuelType? fuel = db.FuelTypes.Find(id);

            if (fuel is null)
            {
                return Results.NotFound();
            }
            
            db.Entry(fuel)
                .CurrentValues
                .SetValues(new FuelType{ Id = id, Name = dto.Name });
            db.SaveChanges();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();
        
        group.MapDelete("/{id:int}", (RentACarContext db, int id) => {
            db.FuelTypes.Where(x => x.Id == id)
                .ExecuteDelete();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();
        
        return app;
    }
    
}