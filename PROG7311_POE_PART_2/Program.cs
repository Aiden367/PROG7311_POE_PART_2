using PROG7311_POE_PART_2.DbContexts;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2;
using PROG7311_POE_PART_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using PROG7311_POE_PART_2.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PROGPOEContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

 
    builder.Services.AddDbContext<PROGPOEContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddAuthentication("CustomScheme")
        .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomScheme", null);

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
        options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
        options.AddPolicy("EmployeePolicy", policy => policy.RequireRole("Employee"));
        options.AddPolicy("FarmerPolicy", policy => policy.RequireRole("Farmer"));
        
    });

    builder.Services.AddScoped<UserService>();
    builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddControllersWithViews();
//builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
//  .AddEntityFrameworkStores<PROGPOEContext>();
var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
  //name: "Home",
 //pattern: "{controller=AddingFarmingProducts}/{action=AddingFarmingProductsView}/{id?}");
app.MapControllerRoute(
  name: "default",
 pattern: "{controller=Register}/{action=RegisterView}/{id?}");


app.Run();


//----------------------------------------------------------END OF FILE---------------------------------------------//