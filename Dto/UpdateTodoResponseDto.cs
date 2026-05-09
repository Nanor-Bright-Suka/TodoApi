namespace TodoApi.Dto;

public class UpdateTodoResponseDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsComplete { get; set; }
}