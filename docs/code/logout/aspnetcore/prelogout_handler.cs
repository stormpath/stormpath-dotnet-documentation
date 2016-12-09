services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreLogoutHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
