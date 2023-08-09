using Application.Quizzes.Commands.Create;
using Application.Quizzes.Queries;
using Carter;
using Mapster;
using MediatR;

namespace Presentation.Endpoints;

public class Quizzes : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("quizzes", async (ISender sender, CreateQuizzRequest request) =>
        {
            var command = request.Adapt<CreateQuizzCommand>();

            var result = await sender.Send(command);

            return result;
        });

        app.MapGet("quizzes", async (ISender sender) =>
        {
            var result = await sender.Send(new GetQuizzesQuery());

            return result;
        });
    }
}
