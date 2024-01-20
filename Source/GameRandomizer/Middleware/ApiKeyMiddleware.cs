namespace GameRandomizer.Middleware;

public class ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
{
    public async Task Invoke(HttpContext context)
    {
        var apiKey = context.Request.Headers["x-api-key"].FirstOrDefault();

        if (!string.IsNullOrEmpty(apiKey) && configuration["ApiKey"]!.Contains(apiKey))
        {
            await next(context);
        }
        else
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}