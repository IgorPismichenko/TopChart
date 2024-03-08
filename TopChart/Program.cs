using TopChart.Models;
using TopChart.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TopChartDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepositoryUsers, UsersRepository>();
builder.Services.AddScoped<IRepositoryTracks, TracksRepository>();
builder.Services.AddScoped<IRepositorySingers, SingersRepository>();
builder.Services.AddScoped<IRepositoryGenres, GenreRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
