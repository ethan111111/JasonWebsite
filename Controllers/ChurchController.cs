using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Data;
using CurrentJasonWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CurrentJasonWebsite.Controllers
{
    public class ChurchController : Controller
    {

        private readonly AppDbContext _context;

        public ChurchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult SubmitChurch()
        {
            return View();
        }

        public IActionResult DisplayChurches()
        {
            var churches = _context.Churches.ToList();
            return View(churches);
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadChurch(string? churchName, string? description, string? location, IFormFile? imageFile )
        {
            byte[]? imageData = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await imageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }


            var church = new Church
            {
                ChurchName = churchName,
                Description = description,
                Location = location,
                ImageData = imageData
            };

            _context.Churches.Add(church);
            await _context.SaveChangesAsync();
            return RedirectToAction("DisplayChurches");
        }
    }



   
}
