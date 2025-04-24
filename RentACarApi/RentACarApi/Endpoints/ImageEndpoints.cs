using RentACarApi.Authentication;
using RentACarApi.Cors;
using RentACarApi.Data;
using RentACarApi.DTOs;
using RentACarApi.Models;

namespace RentACarApi.Endpoints;

public static class ImageEndpoints
{
    private static readonly string ImagePath = Path.Combine("wwwroot", "uploads", "images");
    
    
    public static WebApplication MapImageEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/images");

        group.MapGet("/", (RentACarContext db) => {
            var images = db.Images;
            List<GetImageDto> dtos = new();
            
            foreach (var image in images)
            {
                dtos.Add(new GetImageDto(image.Id, image.CarId, image.Path, image.UploadDate));
            }
            
            return Results.Ok(dtos);
        })
        .RequireCors(CorsHelper.AllowAllOrigins);

        group.MapGet("/{id:int}", (RentACarContext db, int id) => {
            var image = db.Images.Find(id);
            if (image is null)
                return Results.NotFound();
            
            return Results.Ok(new GetImageDto(image.Id, image.CarId, image.Path, image.UploadDate));
        })
        .RequireCors(CorsHelper.AllowAllOrigins);
        
        group.MapPost("/", async (RentACarContext db, HttpRequest request) => {
            // Handling and validating the input
            var image = request.Form.Files.GetFile("image");

            if (image is null || image.Length <= 0)
                return Results.BadRequest("Image is empty");
            
            var carId = request.Form["carId"];
            if (string.IsNullOrWhiteSpace(carId))
                return Results.BadRequest("carId was not provided");

            var imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);

            // Uploading the image
            var path = Path.Combine(ImagePath, imageName);
            using var file = File.Create(path);
            await image.CopyToAsync(file);
            
            // Adding the image metadata to the database
            var imageData = new Image
            {
                CarId = int.Parse(carId),
                Path = imageName,
                UploadDate = DateTime.Now,
            };

            db.Images.Add(imageData);
            db.SaveChanges();
            
            return Results.Ok(new GetImageDto(imageData.Id, imageData.CarId, imageData.Path, imageData.UploadDate));
        })
        .DisableAntiforgery()
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();

        group.MapDelete("/{id:int}", (RentACarContext db, int id) => {
            var image = db.Images.Find(id);
            if (image is null)
                return Results.NotFound();
            
            db.Images.Remove(image);
            File.Delete(Path.Combine(ImagePath, image.Path));
            db.SaveChanges();
            
            return Results.NoContent();
        })
        .RequireCors(CorsHelper.AllowAdminSite)
        .AddEndpointFilter<AuthenticationFilter>();
        
        return app;
    }
        
}