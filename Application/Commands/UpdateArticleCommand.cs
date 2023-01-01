using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record UpdateArticleCommand(Guid Id, ArticleForUpdateDto Article, bool trackChanges) : IRequest;
