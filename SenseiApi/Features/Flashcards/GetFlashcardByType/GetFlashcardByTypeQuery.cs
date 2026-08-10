using MediatR;
namespace SenseiApi.Features.Flashcards.GetFlashcardByType
{
    public record GetFlashcardByTypeQuery() : IRequest<GetFlashcardByTypeResponse>
    {
        public required int FlashcardTypeId { get; init; }
    }

}
