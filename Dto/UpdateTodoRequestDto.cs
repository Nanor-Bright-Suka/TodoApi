


using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto;

public class UpdateTodoRequestDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public bool IsComplete { get; set; }
}