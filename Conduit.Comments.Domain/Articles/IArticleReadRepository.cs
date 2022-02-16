namespace Conduit.Comments.DataAccess.Articles;

public interface IArticleReadRepository
{
    Task<bool> Exists(
        string articleSlug,
        CancellationToken cancellationToken);
}
