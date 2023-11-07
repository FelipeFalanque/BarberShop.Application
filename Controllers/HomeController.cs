using BarberShop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace BarberShop.Application.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Hours()
        {
            var resp = new List<AppointmentViewModel>();

            DateTime date = new DateTime(2023, 11, 7, 8, 0, 0);

            for (int i = 0; i < 20; i++)
            {
                resp.Add(new AppointmentViewModel(date));
                date = date.AddMinutes(30);
            }

            return Ok(resp);
        }
    }
}