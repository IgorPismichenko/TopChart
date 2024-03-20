using TopChart.Models;
using TopChart.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TopChartDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<IRepositoryUsers, UsersRepository>();
builder.Services.AddScoped<IRepositoryTracks, TracksRepository>();
builder.Services.AddScoped<IRepositorySingers, SingersRepository>();
builder.Services.AddScoped<IRepositoryGenres, GenreRepository>();
builder.Services.AddScoped<IRepositoryVideo, VideoRepository>();
builder.Services.AddScoped<IRepositoryComments, CommentsRepository>();
builder.Services.AddScoped<IRepositoryCommentsVideo, CommentsVideoRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
