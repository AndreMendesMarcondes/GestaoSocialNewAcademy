using GSNA.Data.Repositorio;
using GSNA.Domain.DTO.Settings;
using GSNA.Domain.Interfaces.Repositorio;
using GSNA.Domain.Interfaces.Services;
using GSNA.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddScoped<IInstagramDetailsService, InstagramDetailsService>();
builder.Services.AddScoped<IInstagramDetailsRepositorio, InstagramDetailsRepositorio>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
