using MediatR;
using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain.Enums;
using SenseiApi.Persistence;
namespace SenseiApi.Features.Flashcards.GetFlashcardByType
{
    public class GetFlashcardByTypeHandler : IRequestHandler<GetFlashcardByTypeQuery, GetFlashcardByTypeResponse>
    {
        private readonly AppDbContext _dbContext;

        public GetFlashcardByTypeHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetFlashcardByTypeResponse> Handle(GetFlashcardByTypeQuery request, CancellationToken cancellationToken)
        {
            var flashcard = await _dbContext.Flashcards
                .Include(f => f.Translations.Where(b => b.Language == Domain.Enums.Language.English)) //temp
                .Where(f => f.FlashcardType == (FlashcardType)request.FlashcardTypeId)
                .OrderBy(f => Guid.NewGuid())
                .FirstOrDefaultAsync(cancellationToken);

            if (flashcard is null)
            {
                throw new Exception($"No flashcards found for type: {(FlashcardType)request.FlashcardTypeId}");
            }

            return new GetFlashcardByTypeResponse(
                flashcard.Id,
                flashcard.Japanese,
                flashcard.Translations.FirstOrDefault()?.Translation ?? "not found",
                flashcard.FlashcardType
            );
        }
    }
}
