using Conduit.Comments.Domain.Articles;
using Conduit.Shared.Events.Models.Articles.CreateArticle;
using Conduit.Shared.Events.Services;
using Microsoft.Extensions.Logging;

namespace Conduit.Comments.BusinessLogic.Articles;

public class CreateArticleConsumer : IEventConsumer<CreateArticleEventModel>
{
    private readonly IArticleConsumerRepository _articleConsumeRepository;
    private readonly ILogger<CreateArticleConsumer> _logger;

    public CreateArticleConsumer(
        IArticleConsumerRepository articleConsumeRepository,
        ILogger<CreateArticleConsumer> logger)
    {
        _articleConsumeRepository = articleConsumeRepository;
        _logger = logger;
    }

    public async Task ConsumeAsync(
        CreateArticleEventModel message)
    {
        _logger.LogTrace("Received create article model {Message}", message);
        await _articleConsumeRepository.CreateAsync(message);
        _logger.LogTrace("Article added with id {Id}", message.Id);
    }
}
