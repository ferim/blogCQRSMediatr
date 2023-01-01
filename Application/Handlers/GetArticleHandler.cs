
using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal class GetArticleHandler : IRequestHandler<GetArticleQuery, ArticleDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetArticleHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await _repository.Article.GetArticleAsync(request.Id, request.trackChanges);

        if (article == null)
        {
            throw new ArticleNotFoundException(request.Id);
        }

        return _mapper.Map<ArticleDto>(article);
    }
}
