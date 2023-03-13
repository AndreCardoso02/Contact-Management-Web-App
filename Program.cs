// Configuring Page to recieve cookies
using Contact_Management_Web_App.IServices;
using Contact_Management_Web_App.Seeds;
using Contact_Management_Web_App.Services;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Getting the connection string MariaDB from appsettings file
var mariaDBConnectionString = builder.Configuration.GetConnectionString("MariaDB");

// Injecting DBContext to our services, and configurin de project to use MySqlDataBase
builder.Services.AddDbContext<ApplicationDbContext>(context =>
{
    context.UseMySql(
        mariaDBConnectionString,
        ServerVersion.AutoDetect(mariaDBConnectionString));
});

// Configuring cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op =>
{
    op.LoginPath = "/Account/Login";
    op.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

// Configuring Seed Operation
builder.Services.AddTransient<DataSeeder>();
// Injection of dependency
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactService, ContactService>();

// Configuring AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower().Equals("seeddata"))
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory?.CreateScope())
    {
        var service = scope?.ServiceProvider.GetService<DataSeeder>();
        service?.Seed();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configuring Cookies
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}"); 

app.Run();
