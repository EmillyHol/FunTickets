using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunTickets.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl; // pass the returnUrl to the view
            return View();
        }

        // POST: /Account/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {

            var strongusername = Environment.GetEnvironmentVariable("ADMIN_USERNAME");
            var strongpassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

            // Validate username and password
            if (username == strongusername && password == strongpassword)
            {
                // Create a list of claims identifying the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, username), // unique ID
                    new Claim(ClaimTypes.Name, "Administrator"), // human readable name
                           
                };

                // Create the identity from the claims
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign-in the user with the cookie authentication scheme
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));



                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
            
                ViewBag.ErrorMessage = "Invalid username or password.";
            }

            return View();
        }

        // GET: /Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            return View();
        }

        // POST: /Account/Logout
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmed()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account"); // re-direct to /AccountController/Login

        }
    }
}
