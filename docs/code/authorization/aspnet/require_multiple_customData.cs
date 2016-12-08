[Authorize]
[StormpathCustomDataRequired("canPost", true)]
[StormpathCustomDataRequired("userType", "admin")]
public class CreateStickyPostController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
