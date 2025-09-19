using ModularMonolith.Events;

namespace ModularMonolith.Modules.Photos;

public static class UserCreatedEventHandler
{
    public static void Handle(UserCreatedEvent evnt, ILogger logger)
    {
        logger.LogInformation("[Photos] New user created: {FullName} ({UserId}))", evnt.FullName, evnt.UserId);
    }
}