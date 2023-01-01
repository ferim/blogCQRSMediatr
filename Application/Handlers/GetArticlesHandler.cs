
using Application.Queries;
using AutoMapper;
using Contracts;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;
internal sealed class GetArticlesHandler : IRequestHandler<GetArticlesQuery, IEnumerable<ArticleDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetArticlesHandler(IRepositoryManager repository, IMapper mapper) 
    {
        _repository = repository; 
        _mapper = mapper;
    }
    

    public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _repository.Article.GetAllArticlesAsync(request.trackChanges);

        return _mapper.Map<IEnumerable<ArticleDto>>(articles);
    }
}
