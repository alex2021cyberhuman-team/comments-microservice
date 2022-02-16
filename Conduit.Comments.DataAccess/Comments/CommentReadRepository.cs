using Conduit.Comments.Domain.Comments.Domain;
using Conduit.Comments.Domain.Comments.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Comments.DataAccess.Comments;

public class CommentReadRepository : ICommentsReadRepository
{
    private readonly CommentsContext _context;

    public CommentReadRepository(
        CommentsContext context)
    {
        _context = context;
    }

    public async Task<CommentDomainModel?> FindAsync(
        Guid commentId,
        CancellationToken cancellationToken)
    {
        var dbModel =
            await _context.Comment.FindAsync(new object[] { commentId },
                cancellationToken);
        return dbModel?.ToCommentDomainModel();
    }

    public async Task<IList<CommentOutputModel>> GetMultipleAsync(
        string articleSlug,
        Guid? userId,
        CancellationToken cancellationToken)
    {
        var query = _context.Comment.ReturnMultipleQuery(userId, articleSlug);
        var list = await query.ToListAsync(cancellationToken);
        return list;
    }
}
