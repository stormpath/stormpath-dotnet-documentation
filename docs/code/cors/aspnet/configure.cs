public void Configuration(IAppBuilder app)
{
    var corsPolicy = new CorsPolicy
    {
        AllowAnyMethod = false,
        AllowAnyHeader = false,
        AllowAnyOrigin = false,
        SupportsCredentials = true
    };

    corsPolicy.Origins.Add("http://localhost:56789"); // Your API domain

    var corsOptions = new CorsOptions
    {
        PolicyProvider = new CorsPolicyProvider
        {
            PolicyResolver = context => Task.FromResult(corsPolicy)
        }
    };

    app.UseCors(corsOptions);

    app.UseStormpath();

    // Other middleware here...
}
