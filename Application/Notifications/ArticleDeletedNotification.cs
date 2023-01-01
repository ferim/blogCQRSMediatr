
using MediatR;

namespace Application.Notifications;

public sealed record ArticleDeletedNotification(Guid Id, bool TrackChanges) : INotification;
