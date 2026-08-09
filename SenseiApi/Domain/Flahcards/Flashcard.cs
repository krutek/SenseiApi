using SenseiApi.Domain.Enums;

namespace SenseiApi.Domain.Flahcards
{
    public class Flashcard
    {
        public Guid Id { get; private set; }
        public string Japanese { get; private set; }
        public ICollection<FlashcardTranslation> Translations { get; set; } = new List<FlashcardTranslation>();
        private Flashcard() { }
        public Flashcard(string japanese)
        {
            Id = Guid.NewGuid();
            Japanese = japanese;
        }
        public void AddTranslation(string translation, Language language)
        {
            Translations.Add(new FlashcardTranslation(translation, language));
        }
    }
}
