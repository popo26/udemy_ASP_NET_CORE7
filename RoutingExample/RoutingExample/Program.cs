using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

//Register custom constraint to builder
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});
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

    //giving default value for employeename
    endpoints.Map("employee/profile/{employeename:length(4,7):alpha=aioakenfull}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"In Employee profile - {employeeName}");
    });

    //E.g: Optional Prameter(default of id is null): products/details/
    //{id:int?} for route constraint
    endpoints.Map("products/details/{id:int:min(1):max(1000)?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Products details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Products details - id is not supplied");
        }
             
    });

    //Eg: daily-digest-report/{reportdate}
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-digest-report --- {reportDate.ToShortDateString()}");
    });

    //Eg:cities/{cityid}
    // ! means "can't be null"
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City information - {cityId}");
    });

    //E.g:sales-report/2023/apr
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
        {
            await context.Response.WriteAsync($"sales report - {year} - {month}");
        }
        else
        {
            await context.Response.WriteAsync($"{month} is not allowed for sales report");
        }
        
    });
});

//this app.Run executes if the URL is other than specified above.
app.Run(async context => {
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});
app.Run();
