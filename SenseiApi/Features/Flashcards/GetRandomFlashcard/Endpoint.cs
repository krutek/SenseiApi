using MediatR;
using SenseiApi.Binding;
using SenseiApi.Common;
using SenseiApi.Domain.Enums;
namespace SenseiApi.Features.Flashcards.GetRandomFlashcard
{
    public static class Endpoint
    {
        public static IEndpointRouteBuilder MapGetRandomFlashcardsEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/flashcards/random", async (RequestLanguage language ,IMediator mediator) =>
            {
                var query = new GetRandomFlashcardQuery(language.Value);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            });
            return app;
        }
    }
}
