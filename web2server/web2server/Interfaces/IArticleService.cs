using web2server.Dtos;
using web2server.QueryParametars;

namespace web2server.Interfaces
{
    public interface IArticleService
    {
        List<ArticleResponseDto> GetAllArticles(ArticleQueryParameters queryParameters);
        ArticleResponseDto GetArticleById(long id);
        ArticleResponseDto CreateArticle(ArticleRequestDto requestDto, long userId);
        ArticleResponseDto UpdateArticle(long id, ArticleRequestDto requestDto, long userId);
        DeleteResponseDto DeleteArticle(long id, long userId);
    }
}
