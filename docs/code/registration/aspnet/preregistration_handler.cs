app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreRegistrationHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
