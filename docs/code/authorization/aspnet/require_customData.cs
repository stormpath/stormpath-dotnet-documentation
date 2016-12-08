[Authorize]
[StormpathCustomDataRequired("canPost", true)]
public class CreatePostController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
