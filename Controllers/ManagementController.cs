using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;
using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.BarberShop.Domain.Services;
using BarberShop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BarberShop.Application.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISettingsService _settingsService;

        public ManagementController(IUserService userService, ISettingsService settingsService)
        {
            _userService = userService;
            _settingsService = settingsService;
        }
        public IActionResult Home()
        {

            var users = _userService.Get().Select(i => new UserViewModel(i)).ToList();

            return View(users);
        }

        [HttpGet]
        [Route("/Management/Details/{code}")]
        public IActionResult Details(string code)
        {
            var userDB = _userService.Get(code);

            return View(new UserViewModel(userDB));
        }

        [HttpPost]
        public IActionResult Details(UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                var userDB = _userService.Get(user.Code);

                userDB.Name = user.Name;
                userDB.Phone = Util.GetOnlyNumbers(userDB.Phone);
                userDB.Email = user.Email;
                userDB.YearOfBirth = user.YearOfBirth;

                if (!String.IsNullOrEmpty(user.Password))
                {
                    userDB.Password = user.Password.EncodePasswordToBase64();
                }

                _userService.Edit(userDB);

                ViewBag.message = "Success";
            }

            return View(user);
        }

        public IActionResult CreateUser()
        {
            return View(new UserViewModel() { Code = "NeWCoDe" });
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                User userDB = _userService.GetByEmailOrPhone(Util.GetOnlyNumbers(user.Phone));

                if (userDB != null)
                {
                    ModelState.AddModelError("Phone", "Celular em uso por outro cadastro.");
                    return View(user);
                }

                userDB = new User();
                userDB.Name = user.Name;
                userDB.Phone = Util.GetOnlyNumbers(user.Phone);
                userDB.Email = user.Email;
                userDB.YearOfBirth = user.YearOfBirth;

                if (!String.IsNullOrEmpty(user.Password))
                {
                    userDB.Password = user.Password.EncodePasswordToBase64();
                }
                _userService.Add(userDB);

                ViewBag.message = "Success";
            }

            return View(user);
        }

        public IActionResult Packages()
        {
            return View();
        }

        public IActionResult CreatePackages()
        {
            return View();
        }

        public IActionResult DayWork()
        {
            var settingsDays = _settingsService.GetByType(TypeSettings.DayWork);

            // Creating a custom list of weekdays in the desired order
            List<string> weekdaysOrder = new List<string>
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };

            // Sorting the list of objects based on the custom order of weekdays
            var sortedList = settingsDays.OrderBy(e => weekdaysOrder.IndexOf(e.Identifier)).ToList();

            return View(sortedList.Select(i => new SettingsDayWorkViewModel(i)).ToList());
        }

        [HttpPost]
        [Route("/api/management/setdaywork")]
        public IActionResult SetDayWork([FromBody] SettingsDayWorkViewModel settingsDay)
        {
            var dayDB = _settingsService.Get(settingsDay.Code);

            if (dayDB != null)
            {
                dayDB.Start = settingsDay.Start;
                dayDB.End = settingsDay.End;
                dayDB.Value = settingsDay.Open.ToString();

                _settingsService.Edit(dayDB);
            }

            return Ok("Sucesso");
        }
        
        public IActionResult ReservedTimes()
        {
            return View();
        }

        [HttpGet]
        [Route("/api/management/getreservedtimes")]
        public IActionResult GetReservedTimes()
        {
            var reservedtimes = _settingsService.GetByType(TypeSettings.ReservedTimes);

            var reservedtimesVM = reservedtimes.Select(i => new ReservedTimeViewModel(i)).ToList();

            return Ok(reservedtimesVM);
        }

        [HttpPost]
        [Route("/api/management/createreservedtime")]
        public IActionResult CreateReservedTime([FromBody] ReservedTimeViewModel reservedTime)
        {

            var reservedTimeDB = new Settings()
            {
                Code = Guid.NewGuid().ToString(),
                Description = reservedTime.Description,
                Start = reservedTime.Hour,
                Identifier = Util.ConvertDayOfWeekPortugueseToEnglish(reservedTime.Day),
                TypeSettings = TypeSettings.ReservedTimes,
            };

            _settingsService.Add(reservedTimeDB);

            return Ok(reservedTimeDB.Code);
        }

        [HttpPost]
        [Route("/api/management/deletereservedtime")]
        public IActionResult DeleteReservedTime([FromBody] string code)
        {
            var reservedTimeDB = _settingsService.Get(code);
            _settingsService.Delete(reservedTimeDB);

            return Ok("Sucesso");
        }

    }
}
