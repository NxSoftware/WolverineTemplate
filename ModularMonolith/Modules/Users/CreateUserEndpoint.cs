using ModularMonolith.Events;
using Wolverine;
using Wolverine.Http;

namespace ModularMonolith.Modules.Users;

public static class CreateUserEndpoint
{
    [WolverinePost("/users")]
    public static async Task<IResult> Handle(
        IMessageBus messageBus,
        CancellationToken ct)
    {
        await messageBus.PublishAsync(new UserCreatedEvent(
            Guid.NewGuid(),
            "Steve Wilford"));

        return Results.Ok("Hello from Wolverine!");
    }
}
