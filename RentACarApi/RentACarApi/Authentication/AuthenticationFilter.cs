using Microsoft.Extensions.Primitives;
using RentACarApi.Models;

namespace RentACarApi.Authentication;

public class AuthenticationFilter: IEndpointFilter
{
    private readonly IConfiguration configuration;

    public AuthenticationFilter(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(AuthenticationConstants.ApiKeyHeaderName, out var keyValue))
        {
            return Results.Unauthorized();
        }

        var apiKey = configuration.GetValue<string>(AuthenticationConstants.ApiKeyConfigSection);
        if(!apiKey!.Equals(keyValue))
        {
            return Results.Unauthorized();
        }
        
        return await next(context);
    }
}