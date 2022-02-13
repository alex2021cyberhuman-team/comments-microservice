namespace Conduit.Comments.DataAccess.Models;

public class CommentsDbModel
{
    public Guid Id { get; set; }

    public Guid ArticleId { get; set; }

    public ArticleDbModel Article { get; set; } = null!;

    public Guid AuthorId { get; set; }

    public AuthorDbModel Author { get; set; } = null!;
    
    public string Body { get; set; } = string.Empty;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}