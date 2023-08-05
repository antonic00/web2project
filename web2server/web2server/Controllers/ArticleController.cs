using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web2server.Dtos;
using web2server.Interfaces;

namespace web2server.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetAllArticles()
        {
            return Ok(_articleService.GetAllArticles());
        }

        [HttpGet("{id}")]
        public IActionResult GetArticleById(long id)
        {
            return Ok(_articleService.GetArticleById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        public IActionResult CreateArticle([FromBody] ArticleDto articleDto)
        {
            return Ok(_articleService.CreateArticle(articleDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Seller")]
        public IActionResult UpdateArticle(long id, [FromBody] ArticleDto articleDto)
        {
            return Ok(_articleService.UpdateArticle(id, articleDto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Seller")]
        public IActionResult DeleteArticle(long id)
        {
            _articleService.DeleteArticle(id);

            return Ok();
        }
    }
}
