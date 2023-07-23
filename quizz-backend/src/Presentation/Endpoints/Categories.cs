using Application.Categories.Commands.Create;
using Application.Categories.Queries.GetAllCategories;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Endpoints;

public sealed class Categories : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/categories", async (ISender sender, CategoryRequest request) =>
        {
            var result = await sender.Send(new CreateCategoryCommand(request.Name));

            return result;
        });

        app.MapGet("/categories", async (ISender sender) =>
        {
            return await sender.Send(new GetCategoriesQuery());
        });
    }
}
