app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostRegistrationHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
