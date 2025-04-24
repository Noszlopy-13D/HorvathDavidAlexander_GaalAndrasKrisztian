namespace RentACarApi.Cors;

public static class CorsHelper
{
    public static string AllowAllOrigins { get; } = "AllowAllOrigins";
    public static string AllowAdminSite { get; } = "AllowAdminSite";

    // Extension method for setting up CORS
    public static void SetupCors(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddCors(options => {
                options.AddPolicy(AllowAllOrigins, builder => {
                    builder.AllowAnyOrigin()
                        .WithMethods("GET")
                        .AllowAnyHeader();
                });
                
                options.AddPolicy(AllowAdminSite, builder => {
                    builder.WithOrigins(configuration["AdminSiteUrl"] ?? string.Empty)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }
}