namespace SenseiApi.Features.Flashcards
{
    public record FlashcardResponse(
        Guid FlashcardId,
        string Japanese,
        string Answer
    );
}