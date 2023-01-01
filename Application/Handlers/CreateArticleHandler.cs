using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers
{
    internal sealed class CreateArticleHandler : IRequestHandler<CreateArticleCommand, ArticleDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CreateArticleHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ArticleDto> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleEntity = _mapper.Map<Article>(request.Article);

            _repository.Article.CreateArticle(articleEntity);

            await _repository.SaveAsync();

            var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);

            return articleToReturn;
        }
    }
}
