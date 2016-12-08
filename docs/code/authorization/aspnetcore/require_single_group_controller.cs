[Authorize(Policy = "AdminOnly")]
public class AdminController : Controller
{
    // Only users in the admin group can access these actions

    public IActionResult Index()
    {
        return View();
    }
}
