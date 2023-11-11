using BarberShop.Application.BarberShop.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BarberShop.Application.Models;
using BarberShop.Application.BarberShop.Domain.Helpers;
using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult NewLogin()
        {
            var newLogin = new NewLoginViewModel();

            return View(newLogin);
        }

        [HttpPost]
        public async Task<IActionResult> NewLogin(NewLoginViewModel newLogin)
        {
            if (ModelState.IsValid)
            {
                User userDB = _userService.GetByEmailOrPhone(Util.GetOnlyNumbers(newLogin.Celular));

                if (userDB == null)
                {
                    userDB = new User();
                    userDB.Name = newLogin.Nome;
                    userDB.Phone = Util.GetOnlyNumbers(newLogin.Celular);
                    userDB.YearOfBirth = newLogin.AnoNascimento;
                    userDB.Password = newLogin.AnoNascimento.EncodePasswordToBase64();

                    _userService.Add(userDB);
                }
                else
                {
                    ModelState.AddModelError("Celular", "Celular em uso por outro cadastro.");
                    return View(newLogin);
                }

                //Defina pelo menos um conjunto de claims...
                var claims = new List<Claim>
                {
                    //Atributos do usuário ...
                    new Claim(ClaimTypes.Name, userDB.Name),
                    new Claim(ClaimTypes.Role, "Comum"),
                    new Claim(ClaimTypes.MobilePhone, userDB.Phone),
                    new Claim(ClaimTypes.Hash, userDB.Code)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                //Loga de fato
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }

            return View(newLogin);
        }

        public IActionResult Login(string ReturnUrl)
        {
            var login = new LoginViewModel { ReturnURL = ReturnUrl };

            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var userDB = _userService.GetByEmailOrPhone(Util.GetOnlyNumbers(login.Celular));

            if (userDB == null)
                ModelState.AddModelError("Celular", "Celular não encontrado.");
            else
            {
                if (userDB.Password.DecodeFrom64() != login.Senha)
                    ModelState.AddModelError("Senha", "Senha incorreta.");
            }

            //Autenticar
            if (userDB != null && ModelState.IsValid)
            {
                //Defina pelo menos um conjunto de claims...
                var claims = new List<Claim>
                {
                    //Atributos do usuário ...
                    new Claim(ClaimTypes.Name, userDB.Name),
                    new Claim(ClaimTypes.Role, userDB.Administrator ? "Admin" : "Comum"),
                    new Claim(ClaimTypes.Hash, userDB.Code)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                //Loga de fato
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Segura url vazia e url imbutida (somente redireciona para urls do sistema)
                if (!string.IsNullOrEmpty(login.ReturnURL) && Url.IsLocalUrl(login.ReturnURL))
                {
                    return Redirect(login.ReturnURL);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

    }
}
