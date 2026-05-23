using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DenzelDev.Models;
using DenzelDev.Repositories;

namespace DenzelDev.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPortfolioRepository _repository;
        private readonly IConfiguration _configuration;

        public AdminController(IPortfolioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("admin/login")]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("admin/login")]
        public async Task<IActionResult> Login(string password)
        {
            var configuredPassword = _configuration["AdminSettings:Password"] ?? "AdminPassword123!";

            if (password == configuredPassword)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Invalid administrative password.");
            return View();
        }

        [HttpGet]
        [Route("admin/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Projects = await _repository.GetAllProjectsAsync();
            ViewBag.Blogs = await _repository.GetAllBlogsAsync(includeUnpublished: true);
            ViewBag.Messages = await _repository.GetAllMessagesAsync();

            return View();
        }

        #region Projects CRUD Actions
        [HttpGet]
        [Route("admin/projects/create")]
        public IActionResult CreateProject()
        {
            return View(new Project());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/projects/create")]
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                // Auto-generate slug if left empty
                if (string.IsNullOrWhiteSpace(project.Slug))
                {
                    project.Slug = GenerateSlug(project.Title);
                }
                else
                {
                    project.Slug = GenerateSlug(project.Slug);
                }

                // Check for existing slug conflicts
                var existing = await _repository.GetProjectBySlugAsync(project.Slug);
                if (existing != null)
                {
                    ModelState.AddModelError("Slug", "A project with this slug already exists.");
                    return View(project);
                }

                project.CreatedAt = DateTime.UtcNow;
                await _repository.AddProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        [HttpGet]
        [Route("admin/projects/edit/{id}")]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await FindProjectByIdAsync(id);
            if (project == null) return NotFound();
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/projects/edit/{id}")]
        public async Task<IActionResult> EditProject(int id, Project project)
        {
            if (id != project.Id) return NotFound();

            if (ModelState.IsValid)
            {
                project.Slug = GenerateSlug(string.IsNullOrWhiteSpace(project.Slug) ? project.Title : project.Slug);
                
                // Ensure slug uniqueness
                var existing = await _repository.GetProjectBySlugAsync(project.Slug);
                if (existing != null && existing.Id != project.Id)
                {
                    ModelState.AddModelError("Slug", "A project with this slug already exists.");
                    return View(project);
                }

                await _repository.UpdateProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/projects/delete/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _repository.DeleteProjectAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Blogs CRUD Actions
        [HttpGet]
        [Route("admin/blogs/create")]
        public IActionResult CreateBlog()
        {
            return View(new Blog());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/blogs/create")]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Slug = GenerateSlug(string.IsNullOrWhiteSpace(blog.Slug) ? blog.Title : blog.Slug);

                var existing = await _repository.GetBlogBySlugAsync(blog.Slug);
                if (existing != null)
                {
                    ModelState.AddModelError("Slug", "A blog post with this slug already exists.");
                    return View(blog);
                }

                blog.CreatedAt = DateTime.UtcNow;
                if (blog.PublishedDate == default)
                {
                    blog.PublishedDate = DateTime.UtcNow;
                }
                await _repository.AddBlogAsync(blog);
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [HttpGet]
        [Route("admin/blogs/edit/{id}")]
        public async Task<IActionResult> EditBlog(int id)
        {
            var blog = await FindBlogByIdAsync(id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/blogs/edit/{id}")]
        public async Task<IActionResult> EditBlog(int id, Blog blog)
        {
            if (id != blog.Id) return NotFound();

            if (ModelState.IsValid)
            {
                blog.Slug = GenerateSlug(string.IsNullOrWhiteSpace(blog.Slug) ? blog.Title : blog.Slug);

                var existing = await _repository.GetBlogBySlugAsync(blog.Slug);
                if (existing != null && existing.Id != blog.Id)
                {
                    ModelState.AddModelError("Slug", "A blog post with this slug already exists.");
                    return View(blog);
                }

                await _repository.UpdateBlogAsync(blog);
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/blogs/delete/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _repository.DeleteBlogAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Messages Actions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/messages/read/{id}")]
        public async Task<IActionResult> MarkMessageRead(int id)
        {
            await _repository.MarkMessageAsReadAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Helpers
        private string GenerateSlug(string title)
        {
            if (string.IsNullOrEmpty(title)) return string.Empty;
            
            // Convert to lowercase, replace spaces with hyphens, filter special characters
            var lower = title.ToLower().Trim();
            var result = new System.Text.StringBuilder();

            foreach (char c in lower)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result.Append(c);
                }
                else if (c == ' ' || c == '-')
                {
                    result.Append('-');
                }
            }

            // Remove consecutive hyphens
            string slug = result.ToString();
            while (slug.Contains("--"))
            {
                slug = slug.Replace("--", "-");
            }

            return slug.Trim('-');
        }

        private async Task<Project?> FindProjectByIdAsync(int id)
        {
            // Simple helper as our repository queries projects by slug
            var all = await _repository.GetAllProjectsAsync();
            foreach (var p in all)
            {
                if (p.Id == id) return p;
            }
            return null;
        }

        private async Task<Blog?> FindBlogByIdAsync(int id)
        {
            var all = await _repository.GetAllBlogsAsync(includeUnpublished: true);
            foreach (var b in all)
            {
                if (b.Id == id) return b;
            }
            return null;
        }
        #endregion
    }
}
