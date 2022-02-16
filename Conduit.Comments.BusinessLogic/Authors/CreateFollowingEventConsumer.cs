using Conduit.Comments.Domain.Authors;
using Conduit.Shared.Events.Models.Profiles.CreateFollowing;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Authors;

public class
    CreateFollowingEventConsumer : IEventConsumer<CreateFollowingEventModel>
{
    private readonly IAuthorConsumerRepository _repository;

    public CreateFollowingEventConsumer(
        IAuthorConsumerRepository repository)
    {
        _repository = repository;
    }

    public async Task ConsumeAsync(
        CreateFollowingEventModel message)
    {
        await _repository.CreateFollowingAsync(message);
    }
}
