services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreChangePasswordHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
