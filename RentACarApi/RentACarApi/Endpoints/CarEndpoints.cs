using Microsoft.EntityFrameworkCore;
using RentACarApi.Authentication;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;
using RentACarApi.Cors;

namespace RentACarApi.Endpoints;

public static class CarEndpoints
{
    public static WebApplication MapCarEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("cars");

        group.MapGet("/", (RentACarContext db) => {
            List<GetCarDto> dtos = new();

            foreach (Car car in db.Cars)
            {
                dtos.Add(car.ToGetDto());
            }
            
            return Results.Ok(dtos);
        })
        .RequireCors(CorsHelper.AllowAllOrigins);
        
        group.MapGet("/{id:int}", (RentACarContext db, int id) => {
            Car? car = db.Cars.FirstOrDefault(x => x.Id == id);

            if (car is null)
                return Results.NotFound();

            return Results.Ok(car.ToGetDto());
        })
        .RequireCors(CorsHelper.AllowAllOrigins);

        group.MapPost("/", (RentACarContext db, CreateCarDto dto) => {
            Car car = dto.ToCar();

            if (!db.CheckForeignKeys(car))
                return Results.BadRequest();
            
            db.Cars.Add(car);
            db.SaveChanges();
            
            return Results.Created($"/{car.Id}", car.ToGetDto());
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();

        group.MapPut("/{id:int}", (RentACarContext db, int id, UpdateCarDto dto) => {
            Car? car = db.Cars.Find(id);

            if (car is null)
            {
                return Results.NotFound();
            }

            Car newCar = dto.ToCar(id);
            if (!db.CheckForeignKeys(newCar))
                return Results.BadRequest();
            
            db.Entry(car)
                .CurrentValues
                .SetValues(newCar);
            db.SaveChanges();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();

        group.MapDelete("/{id:int}", (RentACarContext db, int id) => {
            db.Cars.Where(x => x.Id == id)
                .ExecuteDelete();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();
        
        return app;
    }
}