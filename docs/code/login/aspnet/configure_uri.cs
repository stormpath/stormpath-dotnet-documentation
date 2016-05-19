app.UseStormpath(new StormpathConfiguration
{
    Web = new WebConfiguration
    {
        Login = new WebLoginRouteConfiguration
        {
            Uri = "/logMeIn"
        }
    }
});
