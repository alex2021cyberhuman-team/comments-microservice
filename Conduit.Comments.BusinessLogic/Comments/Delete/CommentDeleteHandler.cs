using Conduit.Comments.DataAccess.Articles;
using Conduit.Comments.Domain;
using Conduit.Comments.Domain.Comments.Delete;
using Conduit.Comments.Domain.Comments.Domain;
using Conduit.Comments.Domain.Comments.Repositories;

namespace Conduit.Comments.BusinessLogic.Comments.Delete;

public class CommentDeleteHandler : ICommentDeleteHandler
{
    private readonly IArticleReadRepository _articleReadRepository;
    private readonly ICommentsWriteRepository _commentsWriteRepository;
    private readonly ICommentsReadRepository _commentsReadRepository;
    
    public CommentDeleteHandler(
        IArticleReadRepository articleReadRepository,
        ICommentsWriteRepository commentsWriteRepository,
        ICommentsReadRepository commentsReadRepository)
    {
        _articleReadRepository = articleReadRepository;
        _commentsWriteRepository = commentsWriteRepository;
        _commentsReadRepository = commentsReadRepository;
    }

    public async Task<CommentDeleteResponse> HandleAsync(
        CommentDeleteRequest request,
        CancellationToken cancellationToken)
    {
        var isArticleExists =
            await _articleReadRepository.Exists(request.ArticleSlug, cancellationToken);
        if (isArticleExists == false)
        {
            return new(Error.NotFound);
        }

        var comment = await 
            _commentsReadRepository.FindAsync(request.CommentId,
                cancellationToken);
        if (comment is null)
        {
            return new(Error.NotFound);
        }
        
        var canUserDeleteComment = CheckCanUserDeleteComment(comment, request);
        if (canUserDeleteComment == false)
        {
            return new(Error.Forbidden);
        }

        await _commentsWriteRepository.DeleteAsync(request.CommentId);

        return new();
    }

    private bool CheckCanUserDeleteComment(
        CommentDomainModel comment,
        CommentDeleteRequest request)
    {
        return comment.AuthorId == request.AuthorId;
    }
}
