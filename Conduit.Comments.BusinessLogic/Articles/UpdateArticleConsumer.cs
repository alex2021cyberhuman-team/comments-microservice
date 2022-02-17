using Conduit.Comments.Domain.Articles;
using Conduit.Shared.Events.Models.Articles.UpdateArticle;
using Conduit.Shared.Events.Services;
using Microsoft.Extensions.Logging;

namespace Conduit.Comments.BusinessLogic.Articles;

public class UpdateArticleConsumer : IEventConsumer<UpdateArticleEventModel>
{
    private readonly IArticleConsumerRepository _articleConsumeRepository;
    private readonly ILogger<UpdateArticleConsumer> _logger;

    public UpdateArticleConsumer(
        IArticleConsumerRepository articleConsumeRepository,
        ILogger<UpdateArticleConsumer> logger)
    {
        _articleConsumeRepository = articleConsumeRepository;
        _logger = logger;
    }

    public async Task ConsumeAsync(
        UpdateArticleEventModel message)
    {
        _logger.LogTrace("Received update article model {Message}", message);
        await _articleConsumeRepository.UpdateAsync(message);
        _logger.LogTrace("Article updated {Id}", message.Id);
    }
}
