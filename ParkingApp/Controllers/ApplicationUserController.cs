using Microsoft.AspNetCore.Mvc;

namespace ParkingApp.Controllers
{
    public class ApplicationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
