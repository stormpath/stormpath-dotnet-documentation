[HttpGet]
public async Task<IHttpActionResult> FindAccountByEmail(string email)
{
    var application = Request.GetStormpathApplication();

    var foundAccount = await application.GetAccounts()
        .Where(a => a.Email == email)
        .SingleOrDefaultAsync();

    if (foundAccount == null)
    {
        return Ok("No accounts found.");
    }
    else
    {
        return Ok(foundAccount.FullName);
    }
}
