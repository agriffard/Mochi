var builder = WebApplication.CreateBuilder(args);
var logger = builder.AddSerilog();

builder.Services.AddControllersWithViews();

builder.Services.AddBusinessServices();
builder.Services.AddDataRepositories();
builder.Services.AddDataHttpRepositories();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.ConfigureAppSettingsSection(builder.Configuration);

logger.LogInformation("Building application.");
var app = builder.Build();

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

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

logger.LogInformation("Running application.");
app.Run();
