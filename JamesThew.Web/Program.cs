using JamesThew.Web.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Context
builder.Services.AddDbContext<JamesThewDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Authentication & Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.Cookie.Name = "JamesThew.Auth";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        DbInitializer.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Auto-logout middleware for expired members: signs out immediately and redirects to login
app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true && context.User.IsInRole("Member"))
    {
        var path = context.Request.Path.Value?.ToLower() ?? "";
        // Skip static files and auth-related paths
        bool isStaticOrAuth = path.StartsWith("/auth/") ||
            path.StartsWith("/plans/recharge") ||
            path.StartsWith("/css") ||
            path.StartsWith("/js") ||
            path.StartsWith("/images") ||
            path.StartsWith("/lib") ||
            path.StartsWith("/uploads") ||
            path.StartsWith("/favicon") ||
            path.StartsWith("/_") ||
            path.EndsWith(".css") ||
            path.EndsWith(".js") ||
            path.EndsWith(".ico") ||
            path.EndsWith(".svg") ||
            path.EndsWith(".png") ||
            path.EndsWith(".jpg") ||
            path.EndsWith(".webp");

        if (!isStaticOrAuth)
        {
            var dbContext = context.RequestServices.GetRequiredService<JamesThewDbContext>();
            var userIdClaim = context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out int userId))
            {
                var now = DateTime.UtcNow;
                var hasActiveSub = await dbContext.Subscriptions.AnyAsync(s =>
                    s.UserId == userId &&
                    s.ExpiryDate > now &&
                    s.PaymentStatus != "Failed" &&
                    s.PaymentStatus != "Cancelled" &&
                    s.PaymentStatus != "Refunded");

                if (!hasActiveSub)
                {
                    await context.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.Redirect("/Auth/Login?expired=true");
                    return;
                }
            }
        }
    }

    await next();
});

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
