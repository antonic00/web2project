using web2server.Dtos;

namespace web2server.Interfaces
{
    public interface IArticleService
    {
        List<ArticleDto> GetAllArticles();
        ArticleDto GetArticleById(long id);
        ArticleDto CreateArticle(ArticleDto articleDto, long userId);
        ArticleDto UpdateArticle(long id, ArticleDto articleDto, long userId);
        void DeleteArticle(long id, long userId);
    }
}
