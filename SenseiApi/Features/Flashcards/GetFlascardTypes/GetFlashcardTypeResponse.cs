namespace SenseiApi.Features.Flashcards.GetFlashcardTypes
{
    public record GetFlashcardTypeResponse(
        int FlashcardTypeId,
        string FlashcardTypeName
    );
}
