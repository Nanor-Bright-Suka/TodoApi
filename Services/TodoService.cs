using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using TodoApi.Models;
using TodoApi.Data;
using TodoApi.Dto;

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


    public async Task<CreateTodoResponseDto> Create(CreateTodoRequestDto todo)
    {
        var todoItem = new TodoItem { Name = todo.Name};

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return new CreateTodoResponseDto
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };
    }



    public async Task<UpdateTodoResponseDto?> Update(int id, UpdateTodoRequestDto updateTodoDto)
    {
        var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);

        if (todo == null) return null;
        todo.Name = updateTodoDto.Name;
        todo.IsComplete = updateTodoDto.IsComplete;
        await _context.SaveChangesAsync();
        return new UpdateTodoResponseDto
        {
            Id = todo.Id,
            Name = todo.Name,
            IsComplete = todo.IsComplete
        };
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