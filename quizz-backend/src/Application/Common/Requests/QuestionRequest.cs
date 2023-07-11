using Domain.Models;

namespace Application.Common.Requests;
public class QuestionRequest
{
    public string Text { get; set; }
    public List<OptionRequest> Options { get; set; }
}
