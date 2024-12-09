using Microsoft.EntityFrameworkCore;
using LvlUp.Data;
using Microsoft.AspNetCore.Identity;
using LvlUp.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContext<LvlUpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LvlUpContext")));

// Configura��o de identidade
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Adiciona suporte a pap�is
    .AddEntityFrameworkStores<LvlUpContext>();

// Configura��o do redirecionamento de Access Denied
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied"; // Altere para o caminho da sua p�gina personalizada
});

// Adiciona servi�os ao container
builder.Services.AddControllersWithViews();

// Inicializa pap�is ao iniciar a aplica��o
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Chamada para inicializar os pap�is
    await SeedRoles(serviceProvider);
}

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

// M�todo para criar pap�is (Admin, etc.)
async Task SeedRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Cria o papel de Admin, se n�o existir
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Opcional: adiciona um usu�rio Admin padr�o
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
