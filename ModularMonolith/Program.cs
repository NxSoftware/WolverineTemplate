using JasperFx;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.Photos;
using ModularMonolith.Modules.Posts;
using ModularMonolith.Modules.Users;
using Wolverine;
using Wolverine.EntityFrameworkCore;
using Wolverine.Http;
using Wolverine.Postgresql;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var defaultConnectionString = configuration.GetConnectionString("Default"); 

builder.Services
    .AddDbContextPool<PhotosDbContext>(b => b
    .UseNpgsql(defaultConnectionString));

builder.Services
    .AddDbContextPool<UsersDbContext>(b => b
    .UseNpgsql(defaultConnectionString));

builder.Services
    .AddDbContextPool<PostsDbContext>(b => b
    .UseNpgsql(defaultConnectionString));

builder.Host.UseWolverine(opts =>
{
    opts.PersistMessagesWithPostgresql(configuration.GetConnectionString("Default")!);
    opts.UseEntityFrameworkCoreTransactions();

    // This helps Wolverine to use a unified envelope storage across all
    // modules, which in turn should help Wolverine be more efficient with
    // your database
    // opts.Durability.MessageStorageSchemaName = "wolverine";

    // Tell Wolverine that when you have more than one handler for the same
    // message type, they should be executed separately and automatically
    // "stuck" to separate local queues
    opts.MultipleHandlerBehavior = MultipleHandlerBehavior.Separated;

    // *If* you may be using external message brokers in such a way that they
    // are "fanning out" a single message sent from an upstream system into
    // multiple listeners within the same Wolverine process, you'll want to make
    // this setting to tell Wolverine to treat that as completely different messages
    // instead of failing by idempotency checks
    opts.Durability.MessageIdentity = MessageIdentity.IdAndDestination;

    // Not 100% necessary for "modular monoliths", but this makes the Wolverine durable
    // inbox/outbox feature a lot easier to use and DRYs up your message handlers
    opts.Policies.AutoApplyTransactions();

    opts.Policies.UseDurableLocalQueues();
});
builder.Services.AddWolverineHttp();

var app = builder.Build();

app.MapWolverineEndpoints(static o =>
{
    o.WarmUpRoutes = RouteWarmup.Eager;
});

return await app.RunJasperFxCommands(args);
