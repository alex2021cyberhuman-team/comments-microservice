using System.ComponentModel.DataAnnotations;

namespace Conduit.Comments.Domain.Comments.Create;

public class CommentCreateInputModel
{
    [Required]
    public CommentInnerModel Comment { get; set; } = new();

    public class CommentInnerModel
    {
        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
