namespace Conduit.Comments.Domain;

public class CommentsGetMultipleRequest
{
    public Guid? UserId { get; set; }

    public string ArticleSlug { get; set; } = string.Empty;
}
