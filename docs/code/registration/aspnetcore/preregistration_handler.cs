services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreRegistrationHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
