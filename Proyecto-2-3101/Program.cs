using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Repositories;
using Proyecto_2_3101.Services;

var builder = WebApplication.CreateBuilder(args);


// --- ADD THIS BLOCK TO FIX THE MULTIPLICATION BUG ---
var defaultCulture = System.Globalization.CultureInfo.InvariantCulture;
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;
// ----------------------------------------------------


// Add services to the container.
builder.Services.AddControllersWithViews();

//Obtiene la conexion de la base de datos del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Registra la clase EstacionamientoDbContext para hacer la conexion la base de datos
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));

//Registra los repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IJobTypeRepository, JobTypeRepository>();

//Registra los servicios
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();

//Activa la sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor(); //Para accesar la sesión desde el layout


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

//Activa la sesión
app.UseSession();

app.Run();