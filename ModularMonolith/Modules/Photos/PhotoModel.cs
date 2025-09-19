namespace ModularMonolith.Modules.Photos;

public class PhotoModel
{
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;
    
    public Guid PhotographerId { get; set; }
    public UserModel Photographer { get; set; } = null!;
}