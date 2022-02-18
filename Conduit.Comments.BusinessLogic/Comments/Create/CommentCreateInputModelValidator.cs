using Conduit.Comments.Domain.Comments.Create;
using Conduit.Shared.Validation;
using FluentValidation;

namespace Conduit.Comments.BusinessLogic.Comments.Create;

public class CommentCreateInputModelValidator :
    AbstractValidator<CommentCreateInputModel>,
    ICommentCreateInputModelValidator
{
    public CommentCreateInputModelValidator()
    {
        RuleFor(x => x.Comment.Body).NotEmpty().MaximumLength(300);
    }

    async Task<Validation> ICommentCreateInputModelValidator.ValidateAsync(
        CommentCreateInputModel commentCreateInputModel)
    {
        var results = await ValidateAsync(commentCreateInputModel);
        return results.ToValidation();
    }
}
