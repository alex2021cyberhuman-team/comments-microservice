namespace Conduit.Comments.Domain
{
    public class CommentGetSingleResponse : BaseResponse
    {
        public SingleCommentOutputModel Output { get; set; } = new();
    }
}
