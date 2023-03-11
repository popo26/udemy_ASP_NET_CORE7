using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddeware>();
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from middleware 1\n");
    await next(context);
});

//middleware 2
//app.usemiddleware<mycustommiddeware>();
app.UseMyCustomMiddleware();

//middleware 3 -app.Run is short circuit(terminating) middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again form middleware 3\n");
});

app.Run();
