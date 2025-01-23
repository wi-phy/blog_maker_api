using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.DTOs;
using webapi.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles = await context.Articles.Include(a => a.Elements.OrderBy(e => e.Order)).ToListAsync();

            return articles;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = await context.Articles.Include(a => a.Elements.OrderBy(e => e.Order)).FirstOrDefaultAsync(a => a.Id == id);

            if (article == null) return NotFound();

            return article;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(ArticleDto articleDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var article = new Article
            {
                Elements = articleDTO.Elements.Select(e => new ArticleElement
                {
                    Type = e.Type,
                    Content = e.Content,
                    Order = e.Order,
                }).ToList(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Articles.Add(article);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticleById), new { id = article.Id }, article);
        }
    }
}

