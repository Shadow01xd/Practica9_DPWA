using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalProyect.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly AuthRepository _authRepository;

        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel userModel)
        {
            userModel.RoleId = 2;
            ModelState.Remove("Role");
            ModelState.Remove("RoleId");

            if (ModelState.IsValid)
            {
                bool isRegistered = _authRepository.RegisterUser(userModel);

                if (isRegistered)
                {
                    return RedirectToAction(nameof(Login));
                }

                ViewBag.Error = "Registration failed. Please try again.";
            }

            return View(userModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Por favor, ingrese correo y contraseña";
                return View();
            }

            var user = _authRepository.ValidateUser(email, password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("RoleId", user.RoleId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role?.Name ?? string.Empty)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Correo o contraseña incorrectos";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
