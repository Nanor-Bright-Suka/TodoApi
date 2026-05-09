

using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{

      private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }



    [HttpGet]
    public  async Task<ActionResult<List<TodoItem>>> GetAllTodos()
    {
        var allTodos = await _service.GetAll();
        return Ok(allTodos);
    }



    [HttpPost]
   public async Task<ActionResult<TodoItem>> CreateTodo(TodoItem newTodo)
  {
   var createdTodo = await _service.Create(newTodo);
    return Created($"/api/todos/{createdTodo.Id}", createdTodo);
  }



    [HttpPut("{id}")]
   public async Task<ActionResult<TodoItem>> UpdateTodo(int id, TodoItem updatedTodo)
    {
    var updatedTodoItem = await _service.Update(id, updatedTodo);
        if (updatedTodoItem == null) return NotFound();

        return NoContent();
  }



    [HttpDelete("{id}")]
   public async Task<ActionResult<TodoItem>> DeleteTodo(int id)
   {
   var result = await _service.Delete(id);
        if (result == null) return NotFound();
        return NoContent();        
   }








}