using Microsoft.EntityFrameworkCore;
using Wolverine.EntityFrameworkCore;

namespace ModularMonolith.Modules.Users;

public sealed class UsersDbContext : DbContext
{
    // For design-time services
    public UsersDbContext()
    {
    }

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.MapWolverineEnvelopeStorage("WolverineUsers");

        modelBuilder.HasDefaultSchema("Users");
    }
    
    public DbSet<UserModel> Users { get; set; } = null!;
}
