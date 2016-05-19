app.UseStormpath(new StormpathConfiguration
{
    Web = new WebConfiguration
    {
        Register = new WebRegisterRouteConfiguration
        {
            Uri = "/createAccount"
        }
    }
});
