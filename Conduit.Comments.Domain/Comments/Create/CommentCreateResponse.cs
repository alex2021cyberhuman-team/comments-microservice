using Conduit.Comments.Domain.Comments.Queries.Single;

namespace Conduit.Comments.Domain.Comments.Create;

public class CommentCreateResponse : BaseResponse
{
    public SingleCommentOutputModel Output { get; set; } = new();
}
