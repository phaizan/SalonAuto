using Microsoft.AspNetCore.Mvc;

namespace AutoSalon.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
