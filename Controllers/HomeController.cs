using Microsoft.AspNetCore.Mvc;

namespace Inter2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}