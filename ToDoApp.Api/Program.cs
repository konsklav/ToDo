using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables("TODO_");

builder.Services.AddControllers(options => options.Filters.Add(new AuthorizeFilter()));
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

var app = builder.Build();

app.MapOpenApi("/");

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSession();

app.MapControllers();

app.Run();