[HttpPost]
[Authorize]
public async Task<IHttpActionResult> UpdatePassword(string newPassword)
{
    var account = Request.GetStormpathAccount();

    if (account != null)
    {
        account.SetPassword(newPassword);
        await account.SaveAsync();
    }

    return Ok();
}
