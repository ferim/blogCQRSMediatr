using Application.Notifications;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers;

internal sealed class DeleteArticleHandler : INotificationHandler<ArticleDeletedNotification>
{
    private readonly IRepositoryManager _repository;
    public DeleteArticleHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(ArticleDeletedNotification notification, CancellationToken cancellationToken)
    {
        var article = await _repository.Article.GetArticleAsync(notification.Id, notification.TrackChanges);

        if (article == null)
            throw new ArticleNotFoundException(notification.Id);

        _repository.Article.DeleteArticle(article);
        await _repository.SaveAsync();
    }
}
