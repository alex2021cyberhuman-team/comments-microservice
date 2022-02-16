﻿using Conduit.Comments.DataAccess.Articles;
using Conduit.Shared.Events.Models.Articles.DeleteArticle;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Articles;

public class DeleteArticleConsumer : IEventConsumer<DeleteArticleEventModel>
{
    private readonly IArticleConsumerRepository _articleConsumeRepository;

    public DeleteArticleConsumer(
        IArticleConsumerRepository articleConsumeRepository)
    {
        _articleConsumeRepository = articleConsumeRepository;
    }

    public async Task ConsumeAsync(
        DeleteArticleEventModel message)
    {
        await _articleConsumeRepository.RemoveAsync(message);
    }
}
