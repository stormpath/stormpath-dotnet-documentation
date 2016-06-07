public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseCors(builder => builder
      .WithOrigins("http://localhost:56789") // Your API domain
      .AllowCredentials());

    app.UseStormpath();

    // Other middleware here...
}
