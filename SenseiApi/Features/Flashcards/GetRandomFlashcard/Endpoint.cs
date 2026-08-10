using MediatR;
namespace SenseiApi.Features.Flashcards.GetRandomFlashcard
{
    public static class Endpoint
    {
        public static IEndpointRouteBuilder MapGetRandomFlashcardsEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/flashcards/random", async (IMediator mediator) =>
            {
                var query = new GetRandomFlashcardQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            });
            return app;
        }
    }
}
