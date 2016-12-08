[Authorize]
[StormpathGroupsRequired("admin")]
public class AdminController : Controller
{
    // Only users in the admin group can access these actions

    public ActionResult Index()
    {
        return View();
    }
}
