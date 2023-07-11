namespace Domain.Models;
public class Option
{
    public Guid Id { get; set; }
    public string Label { get; set; }
    public bool IsCorrect { get; set; }
    public Guid QuestionId { get; set; }
}
