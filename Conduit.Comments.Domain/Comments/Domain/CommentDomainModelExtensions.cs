using Conduit.Comments.Domain.Comments.Create;

namespace Conduit.Comments.Domain.Comments.Domain;

public static class CommentDomainModelExtensions
{
    public static CommentOutputModel ToCommentOutputModel(
        this CommentDomainModel commentDomainModel,
        bool following = false)
    {
        return new()
        {
            CreatedAt = commentDomainModel.CreatedAt,
            UpdatedAt = commentDomainModel.UpdatedAt,
            Body = commentDomainModel.Body,
            Author =
            {
                Username = commentDomainModel.Author.Username,
                Bio = commentDomainModel.Author.Biography,
                Image = commentDomainModel.Author.Image,
                Following = following
            }
        };
    }

    public static CommentDomainModel ToCommentDomainModel(
        this CommentCreateInputModel createCommentInputModel,
        Guid authorId)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Body = createCommentInputModel.Comment.Body,
            AuthorId = authorId
        };
    }
}
