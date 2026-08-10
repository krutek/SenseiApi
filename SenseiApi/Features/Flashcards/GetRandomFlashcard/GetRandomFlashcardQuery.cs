using MediatR;

namespace SenseiApi.Features.Flashcards.GetRandomFlashcard
{
    public record GetRandomFlashcardQuery() : IRequest<GetRandomFlashcardResponse>;
}
