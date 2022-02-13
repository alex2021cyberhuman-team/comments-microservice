using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Conduit.Comments.DataAccess.Models;

public class ArticleDbModel
{
    public Guid Id { get; set; }

    public string Slug { get; set; } = string.Empty;

    public Guid AuthorId { get; set; }

    public AuthorDbModel Author { get; set; } = null!;
}
