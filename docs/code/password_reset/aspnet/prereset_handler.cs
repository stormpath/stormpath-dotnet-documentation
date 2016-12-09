app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreChangePasswordHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
