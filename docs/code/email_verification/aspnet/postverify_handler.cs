app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostVerifyEmailHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
