public class AccountsController : Controller
{
    private readonly IApplication application;

    public AccountsController(IApplication application)
    {
        this.application = application;
    }

    [HttpGet]
    public async Task<IActionResult> FindAccountByEmail(string email)
    {
        var foundAccount = await application.GetAccounts()
                 .Where(a => a.Email == email)
                 .SingleOrDefaultAsync();

        if (foundAccount == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(foundAccount.FullName);
        }
    }
}
