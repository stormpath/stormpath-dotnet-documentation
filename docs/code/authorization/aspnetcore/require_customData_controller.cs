[Authorize(Policy = "CanPost")]
public class CreatePostController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
