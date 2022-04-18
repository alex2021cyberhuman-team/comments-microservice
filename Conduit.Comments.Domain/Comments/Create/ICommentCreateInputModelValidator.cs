using Conduit.Shared.Validations;

namespace Conduit.Comments.Domain.Comments.Create;

public interface ICommentCreateInputModelValidator
{
    Task<Validation> ValidateAsync(
        CommentCreateInputModel commentCreateInputModel);
}
