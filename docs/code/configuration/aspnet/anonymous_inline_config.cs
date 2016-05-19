app.UseStormpath(new
{
    application = new
    {
        name = "My Application"
    },
    web = new
    {
        register = new
        {
            enabled = false
        }
    }
});
