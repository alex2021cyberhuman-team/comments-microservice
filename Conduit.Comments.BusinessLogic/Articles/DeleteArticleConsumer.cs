using Conduit.Comments.Domain.Articles;
using Conduit.Shared.Events.Models.Articles.DeleteArticle;
using Conduit.Shared.Events.Services;
using Microsoft.Extensions.Logging;

namespace Conduit.Comments.BusinessLogic.Articles;

public class DeleteArticleConsumer : IEventConsumer<DeleteArticleEventModel>
{
    private readonly IArticleConsumerRepository _articleConsumeRepository;
    private readonly ILogger<DeleteArticleConsumer> _logger;

    public DeleteArticleConsumer(
        IArticleConsumerRepository articleConsumeRepository,
        ILogger<DeleteArticleConsumer> logger)
    {
        _articleConsumeRepository = articleConsumeRepository;
        _logger = logger;
    }

    public async Task ConsumeAsync(
        DeleteArticleEventModel message)
    {
        _logger.LogTrace("Received delete article model {Message}", message);
        await _articleConsumeRepository.RemoveAsync(message);
        _logger.LogTrace("Article removed with id {Id}", message.Id);
    }
}
