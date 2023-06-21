var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



builder.Services.AddDistributedMemoryCache(); // or use a distributed cache provider like Redis
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "UserId";
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Adjust the timeout according to your needs
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Customer/Home/Error");
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
        name: "Landing_Page",
        pattern: "{controller=LandingPage}/{action=Index}/{id?}",
        defaults: new { controller = "LandingPage", action = "Index" });
});

app.Run();
