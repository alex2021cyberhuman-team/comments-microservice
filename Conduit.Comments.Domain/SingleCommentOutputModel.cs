namespace Conduit.Comments.Domain
{
    public class SingleCommentOutputModel
    {
        public CommentOutputModel Comment { get; set; } = new();
    }
}