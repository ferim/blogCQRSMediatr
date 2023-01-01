
using Entities.Models;

namespace Contracts
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges);
        Task<Article> GetArticleAsync(Guid articleId, bool trackChanges);
        void CreateArticle(Article article);
        void DeleteArticle(Article article);
    }
}
