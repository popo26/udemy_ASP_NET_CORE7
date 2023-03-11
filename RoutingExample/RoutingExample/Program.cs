var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


////returns Endpoint object
//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//    if (endPoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
//    }
//    await next(context);
//});



//enable routing
app.UseRouting();


////returns Endpoint object
//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//    if (endPoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
//    }
//    await next(context);
//});

//creating end points
app.UseEndpoints(endpoints => {
    ////add your end points
    //endpoints.MapGet("/map1", async(context) => {
    //    await context.Response.WriteAsync("In Map 1");
    //});

    //endpoints.MapPost("/map2", async (context) => {
    //    await context.Response.WriteAsync("In Map 2");
    //});

    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files - {fileName} - {extension}");
    });

    endpoints.Map("employee/profile/{employeename}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"In Employee profile - {employeeName}");
    });
});

//this app.Run executes if the URL is other than specified above.
app.Run(async context => {
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();
