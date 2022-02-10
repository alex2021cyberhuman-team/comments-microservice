namespace Conduit.Comments.Domain
{
    public interface ICommentDeleteHandler
    {
        Task<CommentDeleteResponse> HandleAsync(CommentDeleteRequest request);
    }
}
