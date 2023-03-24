var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //hey builder, add all the controllers as service
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
