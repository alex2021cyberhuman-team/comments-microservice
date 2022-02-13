namespace Conduit.Comments.Domain;

public interface ICommentsGetMultipleHandler
{
    Task<CommentsGetMultipleResponse> HandleAsync(
        CommentsGetMultipleRequest request);
}
