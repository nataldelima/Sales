using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.Data;
using Sales.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("SalesContext") ??
        throw new InvalidOperationException("Connection string 'SalesContext' not found."),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesContext"))));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
    
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Executa o seeding SOMENTE em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var seedingService = services.GetRequiredService<SeedingService>();
            seedingService.Seed();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar o seeding: {ex.Message}");
        }
    }
}

// Configure the HTTP request pipeline.
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