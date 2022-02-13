using System.ComponentModel.DataAnnotations;

namespace Conduit.Comments.Domain;

public class MultipleCommentsOutputModel
{
    [Required]
    public List<CommentOutputModel> Comments { get; set; } = new();
}
