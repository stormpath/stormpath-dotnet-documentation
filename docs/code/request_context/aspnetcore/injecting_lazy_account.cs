public class InjectLazyAccountController : Controller
{
    private readonly IAccount _account;

    public InjectLazyAccountController(Lazy<IAccount> lazyAccount)
    {
        _account = lazyAccount.Value;
    }

    public IActionResult Index()
    {
        if (_account != null)
        {
            // Do something with the Account
        }

        return View();
    }
}
