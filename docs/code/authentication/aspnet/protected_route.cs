// Will require a logged-in user for the routes in this controller
[Authorize]
public class SecretController : ApiController
{
    // GET api/<controller>
    public string Get()
    {
        return "secret!";
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
        // do something
    }

}
