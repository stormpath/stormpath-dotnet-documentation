public async Task<IHttpActionResult> GetDetails()
{
    var account = Request.GetStormpathAccount();

    // If the request is authenticated, do something with the account
    // (like get the account's Custom Data):
    if (account != null)
    {
        var customData = await account.GetCustomDataAsync();
        var favoriteColor = customData["favoriteColor"]?.ToString();

        return Ok(favoriteColor);
    }

    return Ok();
}
