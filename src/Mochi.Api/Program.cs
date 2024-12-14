var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrchardCms();

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();

app.Run();
