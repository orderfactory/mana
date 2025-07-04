var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.OrderFactory_Crew_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.OrderFactory_Crew_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
