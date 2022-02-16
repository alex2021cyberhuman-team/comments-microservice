using Conduit.Comments.DataAccess.Articles;
using Conduit.Shared.Events.Models.Articles.UpdateArticle;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Articles;

public class UpdateArticleConsumer : IEventConsumer<UpdateArticleEventModel>
{
    private readonly IArticleConsumerRepository _articleConsumeRepository;

    public UpdateArticleConsumer(
        IArticleConsumerRepository articleConsumeRepository)
    {
        _articleConsumeRepository = articleConsumeRepository;
    }

    public async Task ConsumeAsync(
        UpdateArticleEventModel message)
    {
        await _articleConsumeRepository.UpdateAsync(message);
    }
}
