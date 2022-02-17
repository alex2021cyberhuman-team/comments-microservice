using Conduit.Comments.DataAccess.Articles;
using Conduit.Comments.Domain;
using Conduit.Comments.Domain.Comments.Create;
using Conduit.Comments.Domain.Comments.Domain;
using Conduit.Comments.Domain.Comments.Repositories;

namespace Conduit.Comments.BusinessLogic.Comments.Create;

public class CommentCreateHandler : ICommentCreateHandler
{
    private readonly ICommentsWriteRepository _commentsWriteRepository;
    private readonly ICommentCreateInputModelValidator _commentCreateInputModelValidator;
    private readonly IArticleReadRepository _articleReadRepository;
    
    public CommentCreateHandler(
        ICommentsWriteRepository commentsWriteRepository,
        ICommentCreateInputModelValidator commentCreateInputModelValidator,
        IArticleReadRepository articleReadRepository)
    {
        _commentsWriteRepository = commentsWriteRepository;
        _commentCreateInputModelValidator = commentCreateInputModelValidator;
        _articleReadRepository = articleReadRepository;
    }

    public async Task<CommentCreateResponse> HandleAsync(
        CommentCreateRequest request,
        CancellationToken cancellationToken)
    {
        var isArticleExists = await 
            _articleReadRepository.Exists(request.ArticleSlug, cancellationToken);
        if (isArticleExists == false)
        {
            return new(Error.NotFound);
        }

        var validation = await _commentCreateInputModelValidator.ValidateAsync(request.Model);
        if (validation == false)
        {
            return new(validation);
        }

        var domainModel = request.Model.ToCommentDomainModel(request.AuthorId);

        await _commentsWriteRepository.CreateAsync(domainModel);

        return new(domainModel.ToCommentOutputModel());
    }
}
