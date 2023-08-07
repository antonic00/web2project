using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web2server.Dtos;
using web2server.Exceptions;
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
            ArticleDto article;

            try
            {
                article = _articleService.GetArticleById(id);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(article);
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        public IActionResult CreateArticle([FromBody] ArticleDto articleDto)
        {
            long userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            ArticleDto article;

            try
            {
                article = _articleService.CreateArticle(articleDto, userId);
            }
            catch (InvalidFieldsException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(article);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Seller")]
        public IActionResult UpdateArticle(long id, [FromBody] ArticleDto articleDto)
        {
            long userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            ArticleDto article;

            try
            {
                article = _articleService.UpdateArticle(id, articleDto, userId);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidFieldsException e)
            {
                return BadRequest(e.Message);
            }
            catch (ForbiddenActionException)
            {
                return Forbid();
            }

            return Ok(article);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Seller")]
        public IActionResult DeleteArticle(long id)
        {
            long userId = long.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            try
            {
                _articleService.DeleteArticle(id, userId);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ForbiddenActionException)
            {
                return Forbid();
            }

            return Ok();
        }
    }
}
