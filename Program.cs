using Microsoft.EntityFrameworkCore;
using LvlUp.Data;
using Microsoft.AspNetCore.Identity;
using LvlUp.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<LvlUpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LvlUpContext")));

// Configuração de identidade
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Adiciona suporte a papéis
    .AddEntityFrameworkStores<LvlUpContext>();

// Configuração do redirecionamento de Access Denied
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied"; // Altere para o caminho da sua página personalizada
});

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
    pattern: "{controller=Store}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Store}/{action=Index}/{id?}");

//    endpoints.MapControllerRoute(
//        name: "admin",
//        pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");
//});


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
