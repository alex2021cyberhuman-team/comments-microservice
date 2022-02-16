using Conduit.Comments.DataAccess.Articles;
using Conduit.Shared.Events.Models.Articles.CreateArticle;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Articles;

public class CreateArticleConsumer : IEventConsumer<CreateArticleEventModel>
{
    private readonly IArticleConsumerRepository _articleConsumeRepository;

    public CreateArticleConsumer(
        IArticleConsumerRepository articleConsumeRepository)
    {
        _articleConsumeRepository = articleConsumeRepository;
    }

    public async Task ConsumeAsync(
        CreateArticleEventModel message)
    {
        await _articleConsumeRepository.CreateAsync(message);
    }
}
