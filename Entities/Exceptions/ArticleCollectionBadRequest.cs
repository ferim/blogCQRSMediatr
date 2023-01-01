
namespace Entities.Exceptions;
public sealed class ArticleCollectionBadRequest : BadRequestException
{
    public ArticleCollectionBadRequest()
        : base("Article collection sent from a client is null.")
    {
    }
}
