using Microsoft.EntityFrameworkCore;
using ProniaMVC.Business.Services.Abstracts;
using ProniaMVC.Business.Services.Concretes;
using ProniaMVC.Core.RepositoryAbstracts;
using ProniaMVC.Data.DAL;
using ProniaMVC.Data.RepositoryConcretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ISliderService,SliderService>();
builder.Services.AddScoped<ISliderRepository,SliderRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
