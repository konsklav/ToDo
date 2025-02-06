using Microsoft.EntityFrameworkCore;
using ToDoApp.Api;
using ToDoApp.Api.Data.Repositories.ToDos;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables("TODO_");

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ToDoRepository>();
builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

var app = builder.Build();

app.MapOpenApi("/");

app.UseHttpsRedirection();
app.UseSession();
app.MapControllers();

app.Run();