using MediatR;
using SenseiApi.Domain.Enums;

namespace SenseiApi.Features.Flashcards.GetRandomFlashcard
{
    public record GetRandomFlashcardQuery(Language Language) : IRequest<GetRandomFlashcardResponse>;
}
