services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostVerifyEmailHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
