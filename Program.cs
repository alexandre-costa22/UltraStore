using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using Microsoft.AspNetCore.Identity;
using UltraStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContext<UltraStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UltraStoreContext")));

// Configura��o de identidade
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UltraStoreContext>();

// Adiciona servi�os ao container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Middleware para arquivos est�ticos
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Middleware para p�ginas de erro personalizadas
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    // Redireciona 404 para a p�gina Error404
    if (response.StatusCode == 404)
    {
        response.Redirect("/Error404");
    }
});

// Configura��o das rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
