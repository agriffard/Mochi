var builder = WebApplication.CreateBuilder(args);
var logger = builder.AddSerilog();

builder.Services.AddBusinessServices();
builder.Services.AddDataRepositories();
builder.Services.AddDataHttpRepositories();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.ConfigureAppSettingsSection(builder.Configuration);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBaseAddress = builder.Configuration["services:api:https:0"];

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseAddress)
});

logger.LogInformation("Building application.");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Refit client registration
//builder.Services
//    .AddRefitClient<IBlogApi>()
//    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseAddress));

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

logger.LogInformation("Running application.");
app.Run();
