namespace Domain.Models;
public class Question
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public List<Option> Options { get; set; }
    public Guid QuizzId { get; set; }
}
