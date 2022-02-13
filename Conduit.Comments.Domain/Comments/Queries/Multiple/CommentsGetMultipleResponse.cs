namespace Conduit.Comments.Domain;

public class CommentsGetMultipleResponse : BaseResponse
{
    public MultipleCommentsOutputModel Output { get; set; } = new();
}
