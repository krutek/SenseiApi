using MediatR;
using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain.Flashcards;
using SenseiApi.Persistence;

namespace SenseiApi.Features.Flashcards.GetRandomFlashcard
{
    public class GetRandomFlashcardHandler : IRequestHandler<GetRandomFlashcardQuery, GetRandomFlashcardResponse>
    {
        private readonly AppDbContext _dbContext;

        public GetRandomFlashcardHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRandomFlashcardResponse> Handle(GetRandomFlashcardQuery request, CancellationToken cancellationToken)
        {
            var count = await _dbContext.Flashcards.CountAsync(cancellationToken);

            if (count == 0)
            {
                throw new InvalidOperationException("No flashcards found");
            }


            var flashcard = await _dbContext.Flashcards
                .Include(f => f.Translations.Where(b => b.Language == request.Language))
                .OrderBy(f => Guid.NewGuid())
                .FirstOrDefaultAsync(cancellationToken);


            return new GetRandomFlashcardResponse(
                flashcard.Id,
                flashcard.Japanese,
                flashcard.Translations.FirstOrDefault()?.Translation ?? "not found");
        }
    }
}
