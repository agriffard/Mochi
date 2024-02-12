var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrchardCms();

var app = builder.Build();

app.UseStaticFiles();
app.UseOrchardCore();

app.Run();
