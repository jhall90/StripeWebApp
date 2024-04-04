using Microsoft.EntityFrameworkCore;
using Stripe;
using StripeWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// add secrets.json after right clicking the app and clicking Manage User Secrets
// done so I can hide the stripe api secret key and Connection string
builder.Configuration.AddUserSecrets<Program>(true);

//Add Connection to DB
builder.Services.AddDbContext<MvcContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Payment}/{action=Index}/{id?}");

app.Run();
