using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebNotas.Models;

var webAppSitio = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
// Add services to the container.

webAppSitio.Services.AddControllersWithViews();
webAppSitio.Services.AddDbContext<WebNotasContext>(options =>
    options.UseMySql(configuration.GetConnectionString("RemoteConnection"),ServerVersion.AutoDetect(configuration.GetConnectionString("RemoteConnection"))));


webAppSitio.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});



var app = webAppSitio.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
  

}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
});

app.UseHttpsRedirection();

//habilitamos la lectura de los archivos que están en la carpeta wwwroot del proyecto
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
