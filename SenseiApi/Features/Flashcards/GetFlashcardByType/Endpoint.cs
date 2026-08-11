using MediatR;
namespace SenseiApi.Features.Flashcards.GetFlashcardByType
{
    public static class Endpoint
    {
        public static IEndpointRouteBuilder MapGetFlashcardByTypeEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/flashcards/type", async (IMediator mediator, int flashcardTypeId) =>
            {
                var query = new GetFlashcardByTypeQuery { FlashcardTypeId = flashcardTypeId };
                var response = await mediator.Send(query);
                return Results.Ok(response);
            })
            .WithName("GetFlashcardByType")
            .WithTags("Flashcards");
            return app;
        }
    }
}
