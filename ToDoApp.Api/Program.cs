using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Api;
using ToDoApp.Api.Data.Repositories.ToDos;
using ToDoApp.Api.Middleware;

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
builder.Services.AddSwaggerGen(options =>
{
    var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xml));
});
builder.Services.AddScoped<ToDoRepository>();
builder.Services.AddDbContext<ToDoContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<SessionManagementMiddleware>();

var app = builder.Build();

app.UseSwagger();
app.UseHttpsRedirection();
app.UseSession();
app.UseMiddleware<SessionManagementMiddleware>();
app.MapControllers();

app.Run();