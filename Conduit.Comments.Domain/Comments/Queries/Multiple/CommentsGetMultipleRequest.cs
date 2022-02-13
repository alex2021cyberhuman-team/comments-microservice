namespace Conduit.Comments.Domain.Comments.Queries.Multiple;

public class CommentsGetMultipleRequest
{
    public Guid? UserId { get; set; }

    public string ArticleSlug { get; set; } = string.Empty;
}
