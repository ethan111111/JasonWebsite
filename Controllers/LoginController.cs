using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


using System.Diagnostics;

using CurrentJasonWebsite.Models;

namespace JasonProject.Controllers;

public class LoginController : Controller
{
    private const string AdminUsername = "admin";
    private const string AdminPassword = "admin123"; // Store securely

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    public IActionResult AdminLogin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AdminLogin(string username, string password)
    {
        if (username == AdminUsername && password == AdminPassword)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            ViewBag.ConsoleMessage = "Hello from ASP.NET Core Controller!";


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Sign in and create the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToAction("Index", "Home"); // Redirect to dashboard
        }

        ViewBag.Error = "Invalid credentials.";
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}