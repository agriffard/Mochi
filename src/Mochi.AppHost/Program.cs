var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Mochi_Api>("api");

builder.AddProject<Projects.Mochi_App>("app")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
