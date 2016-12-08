[Authorize]
[StormpathGroupsRequired("admin")]
[StormpathGroupsRequired("manager")]
public class AdminManagementController : Controller
{
    // Only users in BOTH the admin and manager
    // groups can access these actions

    public ActionResult Index()
    {
        return View();
    }
}
