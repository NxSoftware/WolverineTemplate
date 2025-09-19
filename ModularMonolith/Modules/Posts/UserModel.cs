namespace ModularMonolith.Modules.Posts;

public class UserModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    
    public List<PostModel> Posts { get; set; } = new();
}