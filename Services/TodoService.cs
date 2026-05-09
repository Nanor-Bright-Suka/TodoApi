using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Services;

public class TodoService
{
  private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAll()
    {
        var todos = await _context.TodoItems.ToListAsync();
        return todos;
    }




    public async Task<TodoItem?> GetById(int id)
    {
     var myTodo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);
     return myTodo;
    }


    public async Task<TodoItem> Create(TodoItem todo)
    {
       _context.TodoItems.Add(todo);
    await _context.SaveChangesAsync();
    return todo;
    }


    public async Task<TodoItem?> Update(int id, TodoItem updated)
    {
        var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);

        if (todo == null) return null;
        todo.Name = updated.Name;
        todo.IsComplete = updated.IsComplete;
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<TodoItem?> Delete(int id)
    {
        var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);

        if (todo == null) return null;

        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync();
        return todo;
    }
}