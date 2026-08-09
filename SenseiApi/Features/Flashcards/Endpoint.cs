using MediatR;
namespace SenseiApi.Features.Flashcards
{
    public static class Endpoint
    {
        public static IEndpointRouteBuilder MapFlashcardsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/flashcards/random", async (IMediator mediator) =>
            {
                var query = new FlashcardQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            });
            return app;
        }
    }
}
