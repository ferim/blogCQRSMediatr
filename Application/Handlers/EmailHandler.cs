using Application.Notifications;
using Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers;

internal sealed class EmailHandler : INotificationHandler<ArticleDeletedNotification>
{
    private readonly ILoggerManager _logger;

    public EmailHandler(ILoggerManager logger) => _logger = logger;
    public async Task Handle(ArticleDeletedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogWarn($"Delete action for the article with id: {notification.Id} has occurred.");

        await Task.CompletedTask;
    }
}
