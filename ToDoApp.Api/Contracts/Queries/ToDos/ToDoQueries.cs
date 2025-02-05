using Microsoft.EntityFrameworkCore;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.UseCases.ToDos;

public class ToDoQueries(ToDoContext context)
{
    public async Task<List<ToDo>> GetAllAsync(int userId)
    {
        var toDosList = await context.ToDos
            .Include(t => t.ToDoItems)
            .Include(t => t.CreatedBy)
            .Where(t => t.CreatedBy.Id == userId)
            .ToListAsync();

        return toDosList;
    }

    public async Task<ToDo?> GetByIdAsync(int toDoId, int userId)
    {
        var toDo = await context.ToDos
            .Include(t => t.ToDoItems)
            .Include(t => t.CreatedBy)
            .Where(t => t.CreatedBy.Id == userId)
            .FirstOrDefaultAsync(t => t.Id == toDoId);

        return toDo;
    }
}