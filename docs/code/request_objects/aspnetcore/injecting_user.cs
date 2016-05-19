public class UserController : Controller
{
    [FromServices]
    public Lazy<IAccount> Account { get; set; }

    public async Task<IActionResult> GetDetails()
    {
        // If the request is authenticated, do something with the account
        // (like get the account's Custom Data):
        if (Account.Value != null)
        {
            var customData = await Account.Value.GetCustomDataAsync();
            var favoriteColor = customData["favoriteColor"]?.ToString();

            return Ok(favoriteColor);
        }

        return Ok();
    }
}
