using web2server.Dtos;

namespace web2server.Interfaces
{
    public interface IArticleService
    {
        List<ArticleDto> GetAllArticles();
        ArticleDto GetArticleById(long id);
        ArticleDto CreateArticle(ArticleDto articleDto);
        ArticleDto UpdateArticle(long id, ArticleDto articleDto);
        void DeleteArticle(long id);
    }
}
