public class InjectedServicesController : Controller
{
    private readonly IApplication _stormpathApplication;

    public InjectedServicesController(IApplication stormpathApplication)
    {
        _stormpathApplication = stormpathApplication;
    }

    public IActionResult Index()
    {
        return View();
    }
}
