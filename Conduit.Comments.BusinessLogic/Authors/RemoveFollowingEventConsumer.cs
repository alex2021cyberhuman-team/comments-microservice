using Conduit.Comments.Domain.Authors;
using Conduit.Shared.Events.Models.Profiles.RemoveFollowing;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Authors;

public class
    RemoveFollowingEventConsumer : IEventConsumer<RemoveFollowingEventModel>
{
    private readonly IAuthorConsumerRepository 
        _repository;

    public RemoveFollowingEventConsumer(
        IAuthorConsumerRepository repository)
    {
        _repository = repository;
    }

    public async Task ConsumeAsync(
        RemoveFollowingEventModel message)
    {
        await _repository.RemoveFollowingAsync(message);
    }
}
