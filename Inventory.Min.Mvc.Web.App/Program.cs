using Inventory.Min.Mvc.Web.App;

var builder = WebApplication.CreateBuilder(args);

var identityConfig = new IdentityConfig(builder);
identityConfig.RegisterServices();

var register = new ServicesRegister(builder);
register.RegisterServices();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "items",
    pattern: "{controller=Item}/{action=Items}/{id?}");
app.MapControllerRoute(
    name: "relateditems",
    pattern: "{controller=Item}/{action=Related}/{id?}");
app.MapRazorPages();

app.Run();