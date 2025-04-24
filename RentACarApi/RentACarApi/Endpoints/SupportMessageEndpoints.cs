using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;

namespace RentACarApi.Endpoints;

public static class SupportMessageEndpoints
{
    public static WebApplication MapSupportMessageEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("support_messages");

        group.MapGet("/", (RentACarContext db) => {
            return Results.Ok(db.SupportMessages.ToList());
        });
        
        group.MapGet("/{id:int}", (int id, RentACarContext db) => {
            SupportMessage? message = db.SupportMessages.FirstOrDefault(x => x.Id == id);
            
            if (message is null)
                return Results.NotFound();
            
            return Results.Ok(message);
        });
        
        group.MapPost("/", (CreateSupportMessageDto dto, RentACarContext db) => {
            SupportMessage message = new()
            {
                EmailAddress = dto.EmailAddress,
                Title = dto.Title,
                Message = dto.Message,
                Date = DateTime.Now,
            };
            
            db.SupportMessages.Add(message);
            db.SaveChanges();

            return Results.Created($"/{message.Id}", message);
        })
        .WithParameterValidation();
        
        group.MapDelete("/{id:int}", (int id, RentACarContext db) => {
            db.SupportMessages.Where(x => x.Id == id)
                .ExecuteDelete();
            
            return Results.NoContent();
        });
        
        return app;
    }
}