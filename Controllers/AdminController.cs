using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

[Authorize] // Only logged-in admin can access
public class AdminController : Controller
{
    private static Dictionary<string, string> contentStore = new Dictionary<string, string>
    {
        { "home_intro", "Welcome to our website!" },
        { "about_us", "We are a company that values innovation." }
    };

    // Load Admin Dashboard
    public IActionResult Index()
    {
        return View(contentStore);
    }

    // Save Edited Text
    [HttpPost]
    public IActionResult EditText(string key, string newText)
    {
        if (contentStore.ContainsKey(key))
        {
            contentStore[key] = newText;
        }
        return RedirectToAction("Index");
    }
}
