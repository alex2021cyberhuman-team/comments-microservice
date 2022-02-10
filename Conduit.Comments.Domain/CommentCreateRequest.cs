namespace Conduit.Comments.Domain;

public class CommentCreateRequest
{
    public CommentCreateInputModel Model { get; set; } = new();

    public Guid AuthorId { get; set; }

    public string ArticleSlug { get; set; } = string.Empty;
}
