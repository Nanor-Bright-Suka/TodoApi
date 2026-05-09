

using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Dto;

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
   public async Task<ActionResult<CreateTodoResponseDto>> CreateTodo(CreateTodoRequestDto createTodoDto)
  {
   var createdTodo = await _service.Create(createTodoDto);
    return Created($"/api/todos/{createdTodo.Id}", createdTodo);
  }



    [HttpPut("{id}")]
   public async Task<ActionResult> UpdateTodo(int id, UpdateTodoRequestDto updateTodoDto)
    {
    var updatedTodoItem = await _service.Update(id, updateTodoDto);
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