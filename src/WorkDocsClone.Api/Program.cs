using Microsoft.EntityFrameworkCore;
using WorkDocsClone.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("Sqlite")
            ?? "Data Source=./data/workdocsclone.db";
    options.UseSqlite(cs, x => x.MigrationsAssembly("WorkDocsClone.Infrastructure"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();
