services.AddStormpath(new StormpathOptions()
{
    Configuration = new StormpathConfiguration(), // existing config, if any
    PostLoginHandler = (context, ct) =>
    {
        return Task.FromResult(0);
    }
});
