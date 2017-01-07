app.UseStormpath(new StormpathConfiguration()
{
    Client = new ClientConfiguration()
    {
        BaseUrl = "https://enterprise.stormpath.io/v1"
    }
});
