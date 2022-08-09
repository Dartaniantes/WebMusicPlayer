using Microsoft.EntityFrameworkCore;
using Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSingleton(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audio", "haggard-menuetto_in_fa-minore.mp3"));
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapGet("/audio", (int id) =>
 {
     var fileName = "haggard-menuetto_in_fa-minore.mp3";
     return Results.File(System.IO.File.OpenRead(Path.Combine(app.Environment.WebRootPath, "audio", fileName)),
                                            contentType: "audio/mp3",
                                            fileDownloadName: "HAGGARD - MENUETTO", enableRangeProcessing: true);
 });

app.Run();


