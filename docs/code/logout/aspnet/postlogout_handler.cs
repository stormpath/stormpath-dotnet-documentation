app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostLogoutHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
