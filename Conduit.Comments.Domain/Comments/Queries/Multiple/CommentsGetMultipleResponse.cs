namespace Conduit.Comments.Domain.Comments.Queries.Multiple;

public class CommentsGetMultipleResponse : BaseResponse
{
    public MultipleCommentsOutputModel Output { get; set; } = new();
}
