using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CurrentJasonWebsite.Models;

namespace JasonProject.Controllers;

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

    public IActionResult Analysis()
    {
        return View();
    }

    public IActionResult TableOfContents()
    {
        return View();
    }

    public IActionResult Sources()
    {
        return View();
    }

    public IActionResult About()
    {
        var model = new TextBlockModel
        {
            Id = 1, // Sample ID (if using a database, fetch from DB)
            TextContent = "Welcome to the About Page!" // Default text
        };

        return View(model);
    }
    
    
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
