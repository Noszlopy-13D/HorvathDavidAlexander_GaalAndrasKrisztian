using Microsoft.EntityFrameworkCore;
using RentACarApi.Authentication;
using RentACarApi.Cors;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;

namespace RentACarApi.Endpoints;

public static class CategoryEndpoints
{
    public static WebApplication MapCategoryEndpoints(this WebApplication app)
    {
        
        var group = app.MapGroup("/categories");

        group.MapGet("/", (RentACarContext db) => {
            return Results.Ok(db.Categories.ToList());
        })
        .RequireCors(CorsHelper.AllowAllOrigins);
        
        group.MapGet("/{id:int}", (RentACarContext db, int id) => {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            
            if(category == null)
                return Results.NotFound();
            
            return Results.Ok(category);
        })
        .RequireCors(CorsHelper.AllowAllOrigins);

        group.MapPost("/", (RentACarContext db, CreateCategoryDto dto) => {
            Category category = new Category{Name = dto.Name};
            
            db.Categories.Add(category);
            db.SaveChanges();

            return Results.Created($"/{category.Id}", category);
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();
        
        group.MapPut("/{id:int}", (RentACarContext db, int id, UpdateCategoryDto dto) => {
            Category? category = db.Categories.Find(id);

            if (category is null)
            {
                return Results.NotFound();
            }
            
            db.Entry(category)
                .CurrentValues
                .SetValues(new Category{ Id = id, Name = dto.Name });
            db.SaveChanges();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .WithParameterValidation()
        .AddEndpointFilter<AuthenticationFilter>();
        
        group.MapDelete("/{id:int}", (RentACarContext db, int id) => {
            db.Categories.Where(x => x.Id == id)
                .ExecuteDelete();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();
        
        return app;
    }
    
}