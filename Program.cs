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
    .AddRoles<IdentityRole>() // Adiciona suporte a papéis
    .AddEntityFrameworkStores<UltraStoreContext>();

// Adiciona serviços ao container
builder.Services.AddControllersWithViews();

// Inicializa papéis ao iniciar a aplicação
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Chamada para inicializar os papéis
    await SeedRoles(serviceProvider);
}

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

// Método para criar papéis (Admin, etc.)
async Task SeedRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Cria o papel de Admin, se não existir
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Opcional: adiciona um usuário Admin padrão
    var adminEmail = "admin@gmail.com"; 
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        var defaultAdmin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,
            FullName = "Admin Teste",
            PhoneNumber = "12345678",
        };

        var createAdmin = await userManager.CreateAsync(defaultAdmin, "Admin@123"); // Substitua por uma senha segura
        if (createAdmin.Succeeded)
        {
            await userManager.AddToRoleAsync(defaultAdmin, "Admin");
        }
    }
}
