using SenseiApi.Domain.Enums;

namespace SenseiApi.Domain.Flashcards
{
    public class FlashcardTranslation
    {
        public Guid Id { get; private set; }
        public string Translation { get; private set; }
        public Language Language { get; private set; } = Language.English;
        public Guid FlashcardId { get; private set; }
        private FlashcardTranslation() { }
        public FlashcardTranslation(string translation, Language language)
        {
            Id = Guid.NewGuid();
            Translation = translation;
            Language = language;
        }
    }
}
