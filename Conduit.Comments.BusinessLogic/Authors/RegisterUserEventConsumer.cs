using Conduit.Comments.Domain.Authors;
using Conduit.Shared.Events.Models.Users.Register;
using Conduit.Shared.Events.Services;

namespace Conduit.Comments.BusinessLogic.Authors;

public class RegisterUserEventConsumer : IEventConsumer<RegisterUserEventModel>
{
    private readonly IAuthorConsumerRepository _repository;

    public RegisterUserEventConsumer(
        IAuthorConsumerRepository repository)
    {
        _repository = repository;
    }

    public async Task ConsumeAsync(
        RegisterUserEventModel message)
    {
        await _repository.RegisterAsync(message);
    }
}
