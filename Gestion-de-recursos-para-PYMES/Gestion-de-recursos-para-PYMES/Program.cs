using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;
using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);


builder.Services.AddIdentity<Usuario, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccesoDenegado";
});

// Repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// Servicios
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles y admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var userManager = scope.ServiceProvider
.GetRequiredService<UserManager<Usuario>>();

    string[] roles = {
        Roles.Administrador,
        Roles.Vendedor,
        Roles.Almacenista
    };

    foreach (var role in roles)
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole<int> { Name = role });

    // Administrador
    var adminEmail = "admin@sigrepyme.com";
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var admin = new Usuario
        {
            UserName = adminEmail,
            Email = adminEmail,
            Nombre = "Administrador",
            Apellidos = "Sistema",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(admin, "Admin123!");
        await userManager.AddToRoleAsync(admin, Roles.Administrador);
    }

    // Vendedor
    var vendedorEmail = "vendedor@sigrepyme.com";
    if (await userManager.FindByEmailAsync(vendedorEmail) == null)
    {
        var vendedor = new Usuario
        {
            UserName = vendedorEmail,
            Email = vendedorEmail,
            Nombre = "Juan",
            Apellidos = "Vendedor",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(vendedor, "Vendedor123!");
        await userManager.AddToRoleAsync(vendedor, Roles.Vendedor);
    }

    // Almacenista
    var almacenistaEmail = "almacenista@sigrepyme.com";
    if (await userManager.FindByEmailAsync(almacenistaEmail) == null)
    {
        var almacenista = new Usuario
        {
            UserName = almacenistaEmail,
            Email = almacenistaEmail,
            Nombre = "Pedro",
            Apellidos = "Almacenista",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(almacenista, "Almacenista123!");
        await userManager.AddToRoleAsync(almacenista, Roles.Almacenista);
    }
}

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");




app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();