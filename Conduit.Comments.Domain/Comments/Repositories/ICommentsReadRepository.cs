using Conduit.Comments.Domain.Comments.Domain;

namespace Conduit.Comments.Domain.Comments.Repositories;

public interface ICommentsReadRepository
{
    Task<CommentDomainModel?> FindAsync(
        Guid commentId,
        CancellationToken cancellationToken);

    Task<IList<CommentOutputModel>> GetMultipleAsync(
        string articleSlug,
        Guid? userId,
        CancellationToken cancellationToken);
}
