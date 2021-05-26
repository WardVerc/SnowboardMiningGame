using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class EventController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}