namespace Conduit.Comments.Domain.Comments.Queries.Single;

public class CommentGetSingleRequest
{
    public Guid? UserId { get; set; }

    public string ArticleSlug { get; set; } = string.Empty;

    public Guid CommentId { get; set; }
}
