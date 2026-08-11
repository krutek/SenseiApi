using MediatR;

namespace SenseiApi.Features.Flashcards.GetFlashcardTypes
{
    public static class Endpoint
    {
        public static IEndpointRouteBuilder MapGetFlashcardTypesEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/flashcards/types", async (IMediator mediator) =>
            {
                var query = new GetFlashcardTypeQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetFlashcardTypes")
            .WithTags("Flashcards");
            return app;
        }
    }
}
