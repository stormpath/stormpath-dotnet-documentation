app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreLoginHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
