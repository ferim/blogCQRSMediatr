
using Application.Commands;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers
{
    internal sealed class UpdateArticleHandler : IRequestHandler<UpdateArticleCommand, Unit>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public UpdateArticleHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleEntity = await _repository.Article.GetArticleAsync(request.Id, request.trackChanges);

            if (articleEntity == null)
                    throw new ArticleNotFoundException(request.Id);

            _mapper.Map(request.Article, articleEntity);

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
