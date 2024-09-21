var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.dotnet_aspire_Api>("apiservice");

builder.AddProject<Projects.dotnet_aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
