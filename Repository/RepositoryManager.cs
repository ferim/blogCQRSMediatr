
using Contracts;

namespace Repository; 
public sealed class RepositoryManager : IRepositoryManager 
{   
    private readonly RepositoryContext _repositoryContext;
    
    private readonly Lazy<IArticleRepository> _articleRepository;
   
    public RepositoryManager(RepositoryContext repositoryContext) 
    { _repositoryContext = repositoryContext; _articleRepository = new Lazy<IArticleRepository>(() => new ArticleRepository(repositoryContext)); 
    }
   
    public IArticleRepository Article => _articleRepository.Value; public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync(); 
}
