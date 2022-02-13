using Conduit.Comments.Domain.Comments.Domain;

namespace Conduit.Comments.Domain.Comments.Queries.Single;

public class SingleCommentOutputModel
{
    public CommentOutputModel Comment { get; set; } = new();
}
