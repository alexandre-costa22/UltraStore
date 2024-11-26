using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using Microsoft.AspNetCore.Identity;
using UltraStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<UltraStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UltraStoreContext")));

// Configuração de identidade
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UltraStoreContext>();

// Adiciona serviços ao container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Middleware para arquivos estáticos
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Middleware para páginas de erro personalizadas
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    // Redireciona 404 para a página Error404
    if (response.StatusCode == 404)
    {
        response.Redirect("/Error404");
    }
});

// Configuração das rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
