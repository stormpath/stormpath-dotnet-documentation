app.UseStormpath(new StormpathConfiguration()
{
    Web = new WebConfiguration()
    {
        Produces = new string[] { "application/json" }
    }
});
