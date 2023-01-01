
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record CreateArticleCommand(ArticleForCreationDto Article) : IRequest<ArticleDto>;
