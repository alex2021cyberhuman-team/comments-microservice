namespace Conduit.Comments.Domain.Comments.Queries.Single;

public class CommentGetSingleResponse : BaseResponse
{
    public SingleCommentOutputModel Output { get; set; } = new();
}
