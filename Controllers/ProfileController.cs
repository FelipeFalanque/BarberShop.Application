using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberShop.Application.Controllers
{
    // [Authorize(Policy = "Admin")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Profile()
        {
            var claims = HttpContext.User.Claims;
            string code = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Hash).Value;
            var userDB = _userService.Get(code);

            return View(new UserViewModel(userDB));
        }

        [HttpPost]
        public IActionResult Profile(UserViewModel user)
        {


            if (user != null && ModelState.IsValid)
            {
                var userDB = _userService.Get(user.Code);

                userDB.Name = user.Name;
                userDB.Phone = user.Phone;
                userDB.Email = user.Email;

                _userService.Edit(userDB);

                ViewBag.message = "Success";
            }
            else
            {
                ModelState.AddModelError("Phone", "Celular preenchido incorretamente.");
            }

            return View(user);
        }
    }
}
