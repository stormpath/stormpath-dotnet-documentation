services.AddStormpath(new StormpathConfiguration()
{
    Web = new WebConfiguration()
    {
        IdSite = new WebIdSiteConfiguration()
        {
            Enabled = true
        }
    }
});
