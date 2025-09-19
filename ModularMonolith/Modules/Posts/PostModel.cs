namespace ModularMonolith.Modules.Posts;

public class PostModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    
    public Guid AuthorId { get; set; }
    public UserModel Author { get; set; } = null!;
}