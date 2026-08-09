using MediatR;

namespace SenseiApi.Features.Flashcards
{
    public record FlashcardCommand() : IRequest<FlashcardResponse>;
}
