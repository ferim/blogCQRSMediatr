using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges) =>
       await GetAll(trackChanges)
   .OrderBy(c => c.Title)
   .ToListAsync();

    public async Task<Article> GetArticleAsync(Guid articleId, bool trackChanges) =>
        await GetByCondition(c => c.Id.Equals(articleId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateArticle(Article article) => Create(article);

    public void DeleteArticle(Article article) => Delete(article);

}

