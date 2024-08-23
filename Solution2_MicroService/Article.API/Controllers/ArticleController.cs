using Article.API.Models;
using Article.API.Repositories.Data;
using Article.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly AppDbContext _context;

        public ArticleController(IArticleRepository articleRepository, AppDbContext context)
        {
            _articleRepository = articleRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticlesAsync()
        {
            return Ok(await _articleRepository.GetAll().ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleAsync(int id)
        {
            var detailArticle = await _articleRepository.GetByIdAsync(id);
            if (detailArticle is null) return NotFound();
            return Ok(detailArticle);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ArticleModel entity)
        {
            await _articleRepository.AddAsync(entity);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync(ArticleModel entity)
        {
            await _articleRepository.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            /* var deletedArticle = _articleRepository.Delete(id);
            if (Convert.ToInt32(deletedArticle) == 0) return NotFound();
            return NoContent(deletedArticle); */

            var removeArticle = await _articleRepository.GetByIdAsync(id);
            if (removeArticle == null) return NotFound();
            await _articleRepository.DeleteAsync(removeArticle);
            return NoContent();
        }
    }
}