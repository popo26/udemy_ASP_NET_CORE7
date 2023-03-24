var builder = WebApplication.CreateBuilder(args);

////to add each controller class manually
//builder.Services.AddTransient<HomeController>();

// to add all controller classes as service at once
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();

// this include UseRouting/UseEndpoints/MapControllers all in one.
app.MapControllers();

////instead of using just MapControllers() 
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers(); //to detect all controllers as routes
//});

app.Run();
