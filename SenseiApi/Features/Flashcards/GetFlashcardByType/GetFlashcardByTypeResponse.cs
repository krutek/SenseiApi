using SenseiApi.Domain.Enums;

namespace SenseiApi.Features.Flashcards.GetFlashcardByType
{
    public record GetFlashcardByTypeResponse(
        Guid FlashcardId,
        string Japanese,
        string Answer,
        FlashcardType FlashcardType
    );
}
