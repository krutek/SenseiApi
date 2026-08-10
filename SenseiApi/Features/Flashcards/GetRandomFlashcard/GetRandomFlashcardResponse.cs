namespace SenseiApi.Features.Flashcards.GetRandomFlashcard
{
    public record GetRandomFlashcardResponse(
        Guid FlashcardId,
        string Japanese,
        string Answer
    );
}