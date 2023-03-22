// when wwwroot is not used for static files and instead using custom name e.g."myroot", needs to configure builder.
//Also manually create an empty "wwwroot" folder

using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions() { 
    //by default WebRoot accepts only one
WebRootPath = "myroot"
});
var app = builder.Build();

app.UseStaticFiles(); //works the web root path(myroot)

app.UseStaticFiles(new StaticFileOptions() { 
FileProvider = new PhysicalFileProvider( 
    Path.Combine(builder.Environment.ContentRootPath, "myroot2")
   )}); //works with "myroot2"


//c:\aspnetcore\StaticFilesExample\StaticFilesExample
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello from the browser!");
    });
});

app.Run();




//Below is when using wwwroot as a static folder
//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.UseStaticFiles();

//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello from the browser!");
//    });
//});

//app.Run();
