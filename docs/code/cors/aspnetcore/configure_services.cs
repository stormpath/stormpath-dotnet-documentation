public void ConfigureServices(IServiceCollection services)
{
    // Add other services...

    services.AddCors();
    services.AddStormpath();
}
