namespace ModularMonolith.Modules.Photos;

public class UserModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;

    public List<PhotoModel> Photos { get; set; } = new();
}