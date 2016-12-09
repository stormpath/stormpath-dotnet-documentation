services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostChangePasswordHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
