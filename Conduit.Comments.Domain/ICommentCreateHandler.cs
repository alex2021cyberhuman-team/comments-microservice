namespace Conduit.Comments.Domain
{
    public interface ICommentCreateHandler
    {
        Task<CommentCreateResponse> HandleAsync(CommentCreateRequest request);
    }
}
