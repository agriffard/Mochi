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

logger.LogInformation("Building application.");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

logger.LogInformation("Running application.");
app.Run();
