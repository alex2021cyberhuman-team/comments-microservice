using Conduit.Shared.Events.Models.Articles.CreateArticle;
using Conduit.Shared.Events.Models.Articles.DeleteArticle;
using Conduit.Shared.Events.Models.Articles.UpdateArticle;

namespace Conduit.Comments.DataAccess.Articles;

public interface IArticleConsumerRepository
{
    Task CreateAsync(
        CreateArticleEventModel eventModel);

    Task UpdateAsync(
        UpdateArticleEventModel eventModel);

    Task RemoveAsync(
        DeleteArticleEventModel eventModel);
}
