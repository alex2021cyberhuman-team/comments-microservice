namespace Conduit.Comments.Domain
{
    public static class CommentDomainModelExtensions
    {
        public static CommentOutputModel ToOutput(this CommentDomainModel commentDomainModel, bool following = false) => new()
        {
            CreatedAt = commentDomainModel.CreatedAt,
            UpdatedAt = commentDomainModel.UpdatedAt,
            Body = commentDomainModel.Body,
            Author = {
                Username = commentDomainModel.Author.Username,
                Bio = commentDomainModel.Author.Biography,
                Image = commentDomainModel.Author.Image,
                Following = following
            }
        };

        public static CommentDomainModel FromCreateInput(this CommentCreateInputModel createCommentInputModel, Guid authorId) => new()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Body = createCommentInputModel.Comment.Body,
            AuthorId = authorId
        };
    }


}