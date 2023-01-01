using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class ArticleNotFoundException : NotFoundException
{
    public ArticleNotFoundException(Guid articleId)
        : base($"The article with id: {articleId} doesn't exist in the database.")
    {
    }
}
