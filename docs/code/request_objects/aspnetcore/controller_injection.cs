public class InjectedServicesController : Controller
{
    private readonly IApplication stormpathApplication;

    public InjectedServicesController(IApplication stormpathApplication)
    {
        this.stormpathApplication = stormpathApplication;
    }

    public IActionResult Index()
    {
        return View();
    }
}
