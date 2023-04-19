using AdminSiteUseMVC;
using AdminSiteUseMVC.Helpers;
using AdminSiteUseMVC.Models.IRepository.Admin;
using AdminSiteUseMVC.Models.Services.Admin;
using AdminSiteUseMVC.Models.Services.Brands;
using AdminSiteUseMVC.Models.Services.Categories;
using AdminSiteUseMVC.Models.Services.Email;
using AdminSiteUseMVC.Models.Services.Orders;
using AdminSiteUseMVC.Models.Services.Products;
using AdminSiteUseMVC.Models.Services.ShoppingMethods;
using AdminSiteUseMVC.Models.Services.Stocks;
using AdminSiteUseMVC.Models.Services.UserReviews;
using AdminSiteUseMVC.Options;
using AdminSiteUseMVC.Services.Abstract;
using AdminSiteUseMVC.Services.Concrete;
using DbContextL;
using Domian;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnectionstring")));
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddTransient(typeof(IAdminRepository), typeof(AdminRepository));
builder.Services.AddIdentity<User, Role>(options=>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();
///Add Confirmed Email
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    //options.Password.RequiredLength = 5;
//    //options.Password.RequiredUniqueChars = 1;
//    //options.Password.RequireDigit= false;
//    //options.Password.RequireLowercase= false;
//    //options.Password.RequireUppercase= false;
//    //options.Password.RequireNonAlphanumeric= false;
//    options.SignIn.RequireConfirmedEmail = true;
//});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.Cookie.Name = "YourAppCookieName";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/AdminAccount/LogIN";
    // ReturnUrlParameter requires 
    //using Microsoft.AspNetCore.Authentication.Cookies;
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

//inject ojects
builder.Services.AddScoped<CategoryReopsitory>();
builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<UserReviewRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ShoppingMethodRepository>();
/////////////
///
///
builder.Services.Configure<AzureOptions>(builder.Configuration.GetSection("Azure"));

//Email

builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));
builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddTransient<IImageServices,ImageServices>();

///////////////////Localization//////////
builder.Services.AddLocalization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(JsonStringLocalizerFactory));
    });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG")
    };

    //options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0], uiCulture: supportedCultures[0]);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
//////////
//builder.Services.add
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
/////////////////////Localizatoin/////////////////////
var supportedCultures = new[] { "en-US", "ar-EG"};
var localizationOptions = new RequestLocalizationOptions()
    //.SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
/////////////////////////////
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdminAccount}/{action=SignUp}/{id?}");

app.Run();
