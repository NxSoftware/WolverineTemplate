using ModularMonolith.Events;

namespace ModularMonolith.Modules.Posts;

public static class UserCreatedEventHandler
{
    public static void Handle(UserCreatedEvent evnt, ILogger logger)
    {
        logger.LogInformation("[Posts] New user created: {FullName} ({UserId}))", evnt.FullName, evnt.UserId);
    }
}