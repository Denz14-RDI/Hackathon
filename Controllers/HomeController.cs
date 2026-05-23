using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DenzelDev.Models;
using DenzelDev.Repositories;

namespace DenzelDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioRepository _repository;

        public HomeController(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Retrieve skills from database to pass dynamically
            var skills = await _repository.GetAllSkillsAsync();
            ViewBag.Skills = skills;
            return View(new ContactMessage());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("contact")]
        public async Task<IActionResult> SubmitContact(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                contactMessage.CreatedAt = DateTime.UtcNow;
                contactMessage.IsRead = false;
                await _repository.AddMessageAsync(contactMessage);

                TempData["SuccessMessage"] = "Thank you! Your message has been received successfully.";
                return RedirectToAction(nameof(Index));
            }

            // If model is invalid, reload home index page with validation errors
            var skills = await _repository.GetAllSkillsAsync();
            ViewBag.Skills = skills;
            TempData["ErrorMessage"] = "Validation failed. Please verify your form inputs.";
            return View(nameof(Index), contactMessage);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
