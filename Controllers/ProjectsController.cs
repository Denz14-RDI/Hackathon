using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DenzelDev.Repositories;
using DenzelDev.Services;

namespace DenzelDev.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IPortfolioRepository _repository;
        private readonly IMarkdownService _markdownService;

        public ProjectsController(IPortfolioRepository repository, IMarkdownService markdownService)
        {
            _repository = repository;
            _markdownService = markdownService;
        }

        [HttpGet]
        [Route("projects")]
        public async Task<IActionResult> Index(string? category)
        {
            var projects = string.IsNullOrEmpty(category)
                ? await _repository.GetAllProjectsAsync()
                : await _repository.GetProjectsByCategoryAsync(category);

            ViewBag.SelectedCategory = category;
            return View(projects);
        }

        [HttpGet]
        [Route("projects/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var project = await _repository.GetProjectBySlugAsync(slug);
            if (project == null)
            {
                return NotFound();
            }

            // Convert Markdown content to safe HTML
            ViewBag.HtmlContent = _markdownService.ConvertToHtml(project.FullDescriptionMarkdown);

            return View(project);
        }
    }
}
