using Conduit.Comments.Domain.Comments.Domain;

namespace Conduit.Comments.Domain.Comments.Repositories;

public interface ICommentsReadRepository
{
    Task<CommentOutputModel> GetSingleAsync(
        string articleSlug,
        Guid commentId,
        Guid userId,
        CancellationToken cancellationToken);

    Task<IEnumerable<CommentOutputModel>> GetMultipleAsync(
        string articleSlug,
        Guid userId,
        CancellationToken cancellationToken);
}
