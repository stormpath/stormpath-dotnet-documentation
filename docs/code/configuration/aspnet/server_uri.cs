app.UseStormpath(new StormpathConfiguration()
{
    Web = new WebConfiguration()
    {
        ServerUri = "http://localhost:5000"
    }
});
