# Wolverine Module Monolith Template

This repository is a basic but contrived example of a
modular monolith application using Wolverine for HTTP
endpoints and messaging. 

It is intended to highlight a potential issue (most likely
misconfiguration on my part) with how Wolverine creates
the database schemas for the Inbox/Outbox patterns for
each module.

It is **not** intended to be a good example of how to
structure a modular monolith application.

## Running

The `docker-compose.yml` file will create a Postgres
service to store the modules data along with the Wolverine
Inbox/Outbox tables.

Standard EF Core migrations are in place to create schemas
for each of the modules. To run the migrations against 
the Postgres database, run the following commands:

```bash
cd ModularMonolith
dotnet ef database update --context PostsDbContext
dotnet ef database update --context PhotosDbContext
dotnet ef database update --context UsersDbContext
```

Running the ASP.NET Core application will also create
the Wolverine Inbox/Outbox tables in a dedicated `wolverine`
schema.