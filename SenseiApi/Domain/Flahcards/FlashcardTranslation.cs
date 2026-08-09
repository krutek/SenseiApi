using SenseiApi.Domain.Enums;

namespace SenseiApi.Domain.Flahcards
{
    public class FlashcardTranslation
    {
        public Guid Id { get; private set; }
        public string Translation { get; private set; }
        public Language Language { get; private set; } = Language.English;
        public Guid FlashcardId { get; private set; }
        private FlashcardTranslation() { }
        public FlashcardTranslation(string translation, Guid flashcardId, Language language)
        {
            Id = Guid.NewGuid();
            Translation = translation;
            FlashcardId = flashcardId;
            Language = language;
        }
    }
}
