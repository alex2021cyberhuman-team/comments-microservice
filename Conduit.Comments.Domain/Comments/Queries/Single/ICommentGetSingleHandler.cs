namespace Conduit.Comments.Domain.Comments.Queries.Single;

public interface ICommentGetSingleHandler
{
    Task<CommentGetSingleResponse> HandleAsync(
        CommentGetSingleRequest request);
}
