using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;
using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Application.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private readonly IUserService _userService;

        public ManagementController(IUserService userService)
        {
            _userService = userService;
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
                userDB.Phone = user.Phone;
                userDB.Email = user.Email;

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
                User userDB = new User();
                userDB.Name = user.Name;
                userDB.Phone = user.Phone;
                userDB.Email = user.Email;

                if (!String.IsNullOrEmpty(user.Password))
                {
                    userDB.Password = user.Password.EncodePasswordToBase64();
                }
                _userService.Add(userDB);

                ViewBag.message = "Success";
            }

            return View(user);
        }
    }
}
