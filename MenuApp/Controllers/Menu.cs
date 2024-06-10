using Microsoft.AspNetCore.Mvc;

namespace MenuApp.Controllers
{
    public class Menu : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
