app.UseStormpath(new StormpathMiddlewareOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreVerifyEmailHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});.
