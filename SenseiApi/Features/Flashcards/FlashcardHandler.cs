using MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain.Flahcards;
using SenseiApi.Persistence;

namespace SenseiApi.Features.Flashcards
{
    public class FlashcardHandler : IRequestHandler<FlashcardCommand, FlashcardResponse>
    {
        private readonly AppDbContext _dbContext;

        public FlashcardHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FlashcardResponse> Handle(FlashcardCommand request, CancellationToken cancellationToken)
        {
            var flashcard = await _dbContext.Flashcards
                .Include(f => f.Translations)
                .OrderBy(f => EF.Functions.Random())
                .FirstOrDefaultAsync(cancellationToken);

            if (flashcard is null)
            {
                throw new InvalidOperationException("No flashcards found");
            }

            return new FlashcardResponse(
                flashcard.Id,
                flashcard.Japanese,
                flashcard.Translations.FirstOrDefault()?.Translation ?? "not found");
        }
    }
}
