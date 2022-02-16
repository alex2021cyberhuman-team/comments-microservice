using Conduit.Comments.DataAccess.Articles;
using Conduit.Comments.Domain;
using Conduit.Comments.Domain.Comments.Create;
using Conduit.Comments.Domain.Comments.Domain;
using Conduit.Comments.Domain.Comments.Repositories;

namespace Conduit.Comments.BusinessLogic.Comments.Create;

public class CommentCreateHandler : ICommentCreateHandler
{
    private readonly ICommentsWriteRepository _repository;
    private readonly ICommentCreateInputModelValidator _validator;
    private readonly IArticleReadRepository _articleRepository;
    
    public CommentCreateHandler(
        ICommentsWriteRepository repository,
        ICommentCreateInputModelValidator validator,
        IArticleReadRepository articleRepository)
    {
        _repository = repository;
        _validator = validator;
        _articleRepository = articleRepository;
    }

    public async Task<CommentCreateResponse> HandleAsync(
        CommentCreateRequest request,
        CancellationToken cancellationToken)
    {
        var isArticleExists = await 
            _articleRepository.Exists(request.ArticleSlug, cancellationToken);
        if (isArticleExists == false)
        {
            return new(Error.NotFound);
        }
        
        
        var validation = await _validator.ValidateAsync(request.Model);
        if (validation == false)
        {
            return new(validation);
        }

        var domainModel = request.Model.ToCommentDomainModel(request.AuthorId);

        await _repository.CreateAsync(domainModel);

        return new(domainModel.ToCommentOutputModel());
    }
}
