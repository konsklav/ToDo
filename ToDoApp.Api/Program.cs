using Microsoft.EntityFrameworkCore;
using ToDoApp.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables("TODO_");

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

var app = builder.Build();

app.MapOpenApi("/");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
