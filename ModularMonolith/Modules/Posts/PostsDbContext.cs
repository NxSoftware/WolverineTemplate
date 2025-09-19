using Microsoft.EntityFrameworkCore;
using Wolverine.EntityFrameworkCore;

namespace ModularMonolith.Modules.Posts;

public sealed class PostsDbContext : DbContext
{
    // For design-time services
    public PostsDbContext()
    {
    }

    public PostsDbContext(DbContextOptions<PostsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.MapWolverineEnvelopeStorage("WolverinePosts");

        modelBuilder.HasDefaultSchema("Posts");
    }
    
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<PostModel> Posts { get; set; } = null!;
}
