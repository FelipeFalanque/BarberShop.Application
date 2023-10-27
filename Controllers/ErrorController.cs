using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Application.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
