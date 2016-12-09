app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostChangePasswordHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
