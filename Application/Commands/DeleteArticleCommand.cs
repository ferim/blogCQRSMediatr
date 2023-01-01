using MediatR;

namespace Application.Commands;

public record DeleteArticleCommand(Guid Id, bool TrackChanges) : IRequest;

