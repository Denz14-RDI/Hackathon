using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DenzelDev.Repositories;
using DenzelDev.Services;

namespace DenzelDev.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IPortfolioRepository _repository;
        private readonly IMarkdownService _markdownService;

        public BlogsController(IPortfolioRepository repository, IMarkdownService markdownService)
        {
            _repository = repository;
            _markdownService = markdownService;
        }

        [HttpGet]
        [Route("blogs")]
        public async Task<IActionResult> Index()
        {
            // Only pull published blogs for general audience
            var blogs = await _repository.GetAllBlogsAsync(includeUnpublished: false);
            return View(blogs);
        }

        [HttpGet]
        [Route("blogs/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var blog = await _repository.GetBlogBySlugAsync(slug);
            if (blog == null || !blog.IsPublished)
            {
                return NotFound();
            }

            // Convert Markdown content to HTML
            ViewBag.HtmlContent = _markdownService.ConvertToHtml(blog.ContentMarkdown);

            return View(blog);
        }
    }
}
