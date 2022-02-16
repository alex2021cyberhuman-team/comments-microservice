using Conduit.Comments.Domain;
using Conduit.Comments.Domain.Comments.Domain;

namespace Conduit.Comments.BusinessLogic.Comments.Repositories;

public interface ICommentsWriteRepository
{
    Task<CommentDomainModel> CreateAsync(
        CommentDomainModel commentDomainModel);


    Task<CommentDomainModel?> DeleteAsync(
        string articleSlug);
}
