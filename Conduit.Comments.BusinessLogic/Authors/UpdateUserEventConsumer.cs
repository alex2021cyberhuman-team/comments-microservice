using Conduit.Comments.Domain.Authors;
using Conduit.Shared.Events.Models.Users.Update;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Authors;

public class UpdateUserEventConsumer : IEventConsumer<UpdateUserEventModel>
{
    private readonly IAuthorConsumerRepository _repository;

    public UpdateUserEventConsumer(
        IAuthorConsumerRepository repository)
    {
        _repository = repository;
    }

    public async Task ConsumeAsync(
        UpdateUserEventModel message)
    {
        await _repository.UpdateAsync(message);
    }
}
