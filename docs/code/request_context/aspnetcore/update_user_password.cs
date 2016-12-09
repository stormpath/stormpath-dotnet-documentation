public class UserModificationController : Controller
{
    private readonly IAccount _account;

    public UserModificationController(Lazy<IAccount> lazyAccount)
    {
        _account = lazyAccount.Value;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdatePassword(string newPassword)
    {
        if (_account != null)
        {
            var stormpathAccount = _account;
            stormpathAccount.SetPassword(newPassword);
            await stormpathAccount.SaveAsync();
        }

        return RedirectToAction("Index");
    }
}
