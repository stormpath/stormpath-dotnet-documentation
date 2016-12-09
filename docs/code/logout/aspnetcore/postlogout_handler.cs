services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostLogoutHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
