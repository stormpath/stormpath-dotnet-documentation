public class UserModificationController : Controller
{
    private readonly Lazy<IAccount> account;

    public UserModificationController(Lazy<IAccount> account)
    {
        this.account = account;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdatePassword(string newPassword)
    {
        if (account.Value != null)
        {
            var stormpathAccount = account.Value;
            stormpathAccount.SetPassword(newPassword);
            await stormpathAccount.SaveAsync();
        }

        return RedirectToAction("Index");
    }
}
