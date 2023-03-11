using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddeware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts");
            await next(context);
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        { 
        return app.UseMiddleware<MyCustomMiddeware>();
        }
    }
}
