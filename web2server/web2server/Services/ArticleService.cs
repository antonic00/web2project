using AutoMapper;
using web2server.Dtos;
using web2server.Infrastructure;
using web2server.Interfaces;
using web2server.Models;

namespace web2server.Services
{
    public class ArticleService : IArticleService
    {
        private readonly WebshopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleService(WebshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ArticleDto CreateArticle(ArticleDto articleDto)
        {
            Article article = _mapper.Map<Article>(articleDto);

            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();

            return _mapper.Map<ArticleDto>(article);
        }

        public void DeleteArticle(long id)
        {
            Article article = _dbContext.Articles.Find(id);

            _dbContext.Articles.Remove(article);
            _dbContext.SaveChanges();
        }

        public List<ArticleDto> GetAllArticles()
        {
            return _mapper.Map<List<ArticleDto>>(_dbContext.Articles.ToList());
        }

        public ArticleDto GetArticleById(long id)
        {
            return _mapper.Map<ArticleDto>(_dbContext.Articles.Find(id));
        }

        public ArticleDto UpdateArticle(long id, ArticleDto articleDto)
        {
            Article article = _dbContext.Articles.Find(id);
            article.Name = articleDto.Name;
            article.Price = articleDto.Price;
            article.Quantity = articleDto.Quantity;
            article.Description = articleDto.Description;

            _dbContext.SaveChanges();

            return _mapper.Map<ArticleDto>(article);

        }
    }
}
