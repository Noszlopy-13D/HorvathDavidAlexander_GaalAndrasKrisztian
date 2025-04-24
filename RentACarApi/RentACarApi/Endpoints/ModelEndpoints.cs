using Microsoft.EntityFrameworkCore;
using RentACarApi.Authentication;
using RentACarApi.Cors;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;

namespace RentACarApi.Endpoints;

public static class ModelEndpoints
{
    public static WebApplication MapModelEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/models");
        
        group.MapGet("/", (RentACarContext db) => {

            List<GetModelDto> dtos = new();
            foreach (var model in db.Models)
            {
                dtos.Add(model.ToGetDto());
            }
            
            return Results.Ok(dtos);
        })
        .RequireCors(CorsHelper.AllowAllOrigins);

        group.MapGet("/{id:int}", (RentACarContext db, int id) => {
            Model? model = db.Models.FirstOrDefault(x => x.Id == id);

            if (model is null)
                return Results.NotFound();

            return Results.Ok(model.ToGetDto());
        })
        .RequireCors(CorsHelper.AllowAllOrigins);
        
        group.MapPost("/", (RentACarContext db, CreateModelDto dto) => {
            Model model = dto.ToModel();
            
            if (!db.CheckForeignKeys(model))
                return Results.BadRequest();

            db.Models.Add(model);
            db.SaveChanges();
            
            return Results.Created($"models/{model.Id}", model.ToGetDto());
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();

        group.MapPut("/{id:int}", (RentACarContext db, int id, UpdateModelDto dto) => {
            Model? model = db.Models.Find(id);

            if (model is null)
            {
                return Results.NotFound();
            }

            Model newModel = dto.ToModel(id);
            if (!db.CheckForeignKeys(newModel))
                return Results.BadRequest();
            
            db.Entry(model)
                .CurrentValues
                .SetValues(newModel);
            db.SaveChanges();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();

        group.MapDelete("/{id:int}", (RentACarContext db, int id) => {
            db.Models.Where(x => x.Id == id)
                .ExecuteDelete();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();
        
        return app;
    }
}