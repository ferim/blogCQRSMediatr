using Application.Commands;
using Application.Notifications;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace blogMediator.Controllers;

[ApiController]
[Route("api/article")]
public class ArticlesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;
    public ArticlesController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
        var articles = await _sender.Send(new GetArticlesQuery(false));
        return Ok(articles);
    }

    [HttpGet("{id:guid}", Name = "ArticleById")]
    public async Task<IActionResult> GetArticle(Guid id)
    {
        var article = await _sender.Send(new GetArticleQuery(id, false));
        return Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] ArticleForCreationDto articleForCreationDto)
    {   
        var article = await _sender.Send(new CreateArticleCommand(articleForCreationDto));

        return CreatedAtRoute("ArticleById", new { id = article.Id }, article);
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateArticle(Guid id, ArticleForUpdateDto articleForUpdateDto)
    {
        if (articleForUpdateDto is null)
            return BadRequest("articleForUpdateDto object is null.");

        await _sender.Send(new UpdateArticleCommand(id, articleForUpdateDto, true));

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
        await _publisher.Publish(new ArticleDeletedNotification(id, false));
        return NoContent();
    }
}
