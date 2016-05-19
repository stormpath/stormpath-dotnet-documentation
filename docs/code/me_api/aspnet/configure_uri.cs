app.UseStormpath(new StormpathConfiguration
{
    Web = new WebConfiguration
    {
        Me = new WebMeRouteConfiguration
        {
            Uri = "/userDetails"
        }
    }
});
