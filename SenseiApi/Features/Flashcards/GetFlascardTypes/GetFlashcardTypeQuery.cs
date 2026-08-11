using MediatR;
namespace SenseiApi.Features.Flashcards.GetFlashcardTypes
{
    public record GetFlashcardTypeQuery : IRequest<List<GetFlashcardTypeResponse>>
    {
    }
}
