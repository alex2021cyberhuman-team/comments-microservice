using Conduit.Shared.Events.Models.Users.Register;
using Conduit.Shared.Events.Models.Users.Update;

namespace Conduit.Comments.Domain.Authors;

public interface IAuthorConsumerRepository
{
    Task RegisterAsync(
        RegisterUserEventModel eventModel);

    Task UpdateAsync(
        UpdateUserEventModel eventModel);
}
