using Microsoft.EntityFrameworkCore;
using Wolverine.EntityFrameworkCore;

namespace ModularMonolith.Modules.Photos;

public sealed class PhotosDbContext : DbContext
{
    // For design-time services
    public PhotosDbContext()
    {
    }

    public PhotosDbContext(DbContextOptions<PhotosDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.MapWolverineEnvelopeStorage("WolverinePhotos");

        modelBuilder.HasDefaultSchema("Photos");
    }
    
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<PhotoModel> Photos { get; set; } = null!;
}
