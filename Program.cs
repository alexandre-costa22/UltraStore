using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using Microsoft.AspNetCore.Identity;
using UltraStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UltraStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UltraStoreContext")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UltraStoreContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
