
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetArticleQuery(Guid Id, bool trackChanges) : IRequest<ArticleDto>;
