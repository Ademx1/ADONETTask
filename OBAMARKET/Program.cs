var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
    );


app.Run();