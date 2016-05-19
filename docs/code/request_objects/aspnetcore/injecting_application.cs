public class AccountsController : Controller
{
    [FromServices]
    public IApplication StormpathApplication { get; set; }

    [HttpGet]
    public async Task<IActionResult> FindAccountByEmail(string email)
    {
        var foundAccount = await StormpathApplication.GetAccounts()
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
}
