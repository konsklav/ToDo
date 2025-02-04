using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Data.Configurations;
using ToDoApp.Api.Models;

namespace ToDoApp.Api;

public class ToDoContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<ToDoItem> ToDoItems { get; set; }

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ToDoConfiguration());
        modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}