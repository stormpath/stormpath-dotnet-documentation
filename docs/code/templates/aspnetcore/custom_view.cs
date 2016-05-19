services.AddStormpath(new StormpathConfiguration
{
    Web = new WebConfiguration
    {
        Login = new WebLoginRouteConfiguration
        {
            View = "~/Views/Login/MyLogin.cshtml"
        }
    }
});
