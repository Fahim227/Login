var builder = WebApplication.CreateBuilder(args);

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

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
        name: "getData",
        pattern: "getData",
        defaults: new { controller = "Home", action = "getData" });

    endpoints.MapControllerRoute(
        name: "Home",
        pattern: "Home2",
        defaults: new { controller = "Home", action = "Home2" });

    endpoints.MapControllerRoute(
        name: "Home",
        pattern: "Home",
        defaults: new { controller = "Home", action = "Index" });
}
);


app.Run();
