namespace Conduit.Comments.Domain;

public interface ICommentGetSingleHandler
{
    Task<CommentGetSingleResponse> HandleAsync(
        CommentGetSingleRequest request);
}
