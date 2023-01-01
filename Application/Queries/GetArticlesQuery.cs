
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetArticlesQuery(bool trackChanges) : IRequest<IEnumerable<ArticleDto>>;

