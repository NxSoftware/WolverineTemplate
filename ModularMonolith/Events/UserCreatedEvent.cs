namespace ModularMonolith.Events;

public record UserCreatedEvent(Guid UserId, string FullName);