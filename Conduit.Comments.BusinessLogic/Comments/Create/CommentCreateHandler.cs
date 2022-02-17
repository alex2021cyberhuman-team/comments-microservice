using Conduit.Comments.Domain;
using Conduit.Comments.Domain.Articles;
using Conduit.Comments.Domain.Comments.Create;
using Conduit.Comments.Domain.Comments.Models;
using Conduit.Comments.Domain.Comments.Repositories;
using Conduit.Shared.Events.Models.Comments.CreateComment;
using Conduit.Shared.Events.Models.Comments.DeleteComment;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Comments.Create;

public class CommentCreateHandler : ICommentCreateHandler
{
    private readonly ICommentsWriteRepository _commentsWriteRepository;

    private readonly ICommentCreateInputModelValidator
        _commentCreateInputModelValidator;

    private readonly IArticleReadRepository _articleReadRepository;

    private readonly IEventProducer<CreateCommentEventModel>
        _createCommentEventModelEventProducer;

    public CommentCreateHandler(
        ICommentsWriteRepository commentsWriteRepository,
        ICommentCreateInputModelValidator commentCreateInputModelValidator,
        IArticleReadRepository articleReadRepository,
        IEventProducer<CreateCommentEventModel>
            createCommentEventModelEventProducer)
    {
        _commentsWriteRepository = commentsWriteRepository;
        _commentCreateInputModelValidator = commentCreateInputModelValidator;
        _articleReadRepository = articleReadRepository;
        _createCommentEventModelEventProducer =
            createCommentEventModelEventProducer;
    }

    public async Task<CommentCreateResponse> HandleAsync(
        CommentCreateRequest request,
        CancellationToken cancellationToken)
    {
        var articleDomainModel =
            await _articleReadRepository.FindAsync(request.ArticleSlug,
                cancellationToken);
        if (articleDomainModel is null)
        {
            return new(Error.NotFound);
        }

        var validation =
            await _commentCreateInputModelValidator
                .ValidateAsync(request.Model);
        if (validation == false)
        {
            return new(validation);
        }

        var domainModel = request.Model.ToCommentDomainModel(request.AuthorId,
            articleDomainModel.Id, request.ArticleSlug);

        await _commentsWriteRepository.CreateAsync(domainModel);
        var createCommentEventModel = new CreateCommentEventModel()
        {
            Id = domainModel.Id,
            Body = domainModel.Body,
            ArticleId = domainModel.ArticleId,
            CreatedAt = domainModel.CreatedAt,
            UpdatedAt = domainModel.UpdatedAt,
            UserId = request.AuthorId
        };
        
        await _createCommentEventModelEventProducer.ProduceEventAsync(
            createCommentEventModel);
            
        return new(domainModel.ToCommentOutputModel());
    }
}
