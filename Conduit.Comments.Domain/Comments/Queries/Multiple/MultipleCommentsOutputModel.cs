using System.ComponentModel.DataAnnotations;
using Conduit.Comments.Domain.Comments.Domain;

namespace Conduit.Comments.Domain.Comments.Queries.Multiple;

public class MultipleCommentsOutputModel
{
    [Required]
    public List<CommentOutputModel> Comments { get; set; } = new();
}
