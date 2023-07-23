using Application.Questions.Commands.CreateQuestion;
using Application.Questions.Queries.GetQuestions;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Endpoints;

public class Questions : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/question/create", async (ISender sender, [FromBody] QuestionRequest request) =>
        {
            var questionResult = await sender.Send(new CreateQuestionCommand(request.Text, request.Options, request.QuizzId));
            return questionResult;
        });

        app.MapGet("/questions", async (ISender sender) =>
        {
            return await sender.Send(new GetAllQuestionsQuery());
        });
    }
}
