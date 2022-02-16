using Conduit.Comments.Domain.Comments.Domain;

namespace Conduit.Comments.Domain.Comments.Repositories;

public interface ICommentsWriteRepository
{
    Task<CommentDomainModel> CreateAsync(
        CommentDomainModel commentDomainModel);


    Task<CommentDomainModel?> DeleteAsync(
        string articleSlug);
}
