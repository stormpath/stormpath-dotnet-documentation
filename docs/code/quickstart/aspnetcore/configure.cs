public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // Logging and static file middleware (if applicable)

    app.UseStormpath();

    // MVC or other framework middleware here
}
