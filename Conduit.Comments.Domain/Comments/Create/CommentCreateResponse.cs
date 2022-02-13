namespace Conduit.Comments.Domain;

public class CommentCreateResponse : BaseResponse
{
    public SingleCommentOutputModel Output { get; set; } = new();
}
