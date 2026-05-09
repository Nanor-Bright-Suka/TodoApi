

namespace TodoApi.Dto;

public class CreateTodoResponseDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsComplete { get; set; }
}