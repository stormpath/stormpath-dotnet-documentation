services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PreLoginHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
