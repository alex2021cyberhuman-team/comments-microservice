namespace Conduit.Comments.Domain.Comments.Queries.Multiple;

public interface ICommentsGetMultipleHandler
{
    Task<CommentsGetMultipleResponse> HandleAsync(
        CommentsGetMultipleRequest request);
}
