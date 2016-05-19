public IHttpActionResult Get()
{
    var client = Request.GetStormpathClient();
    var application = Request.GetStormpathApplication();
    var account = Request.GetStormpathAccount();

    // Do something with these objects...

    return Ok();
}
