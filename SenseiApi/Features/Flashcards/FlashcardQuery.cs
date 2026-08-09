using MediatR;

namespace SenseiApi.Features.Flashcards
{
    public record FlashcardQuery() : IRequest<FlashcardResponse>;
}
