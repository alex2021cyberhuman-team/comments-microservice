namespace Conduit.Comments.Domain.Articles;

public interface IArticleReadRepository
{
    Task<bool> Exists(
        string articleSlug,
        CancellationToken cancellationToken);
}
