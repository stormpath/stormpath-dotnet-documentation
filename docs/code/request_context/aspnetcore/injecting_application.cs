public class AccountsController : Controller
{
    private readonly IApplication _application;

    public AccountsController(IApplication application)
    {
        _application = application;
    }

    [HttpGet]
    public async Task<IActionResult> FindAccountByEmail(string email)
    {
        var foundAccount = await _application.GetAccounts()
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
