using SenseiApi.Domain.Enums;

namespace SenseiApi.Domain.Flahcards
{
    public class Flashcard
    {
        public Guid Id { get; private set; }
        public string Japanese { get; private set; }
        public FlashcardType FlashcardType { get; private set; }
        public ICollection<FlashcardTranslation> Translations { get; set; } = new List<FlashcardTranslation>();
        private Flashcard() { }
        public Flashcard(string japanese, FlashcardType flashcardType)
        {
            Id = Guid.NewGuid();
            Japanese = japanese;
            FlashcardType = flashcardType;
        }
        public void AddTranslation(string translation, Language language)
        {
            Translations.Add(new FlashcardTranslation(translation, language));
        }
    }
}
