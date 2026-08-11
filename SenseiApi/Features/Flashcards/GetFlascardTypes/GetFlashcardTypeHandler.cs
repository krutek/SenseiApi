using MediatR;
using SenseiApi.Domain.Enums;
using SenseiApi.Persistence;

namespace SenseiApi.Features.Flashcards.GetFlashcardTypes
{
    public class GetFlashcardTypeHandler : IRequestHandler<GetFlashcardTypeQuery, List<GetFlashcardTypeResponse>>
    {
        private readonly AppDbContext _dbContext;

        public GetFlashcardTypeHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetFlashcardTypeResponse>> Handle(GetFlashcardTypeQuery request, CancellationToken cancellationToken)
        {
            var types = Enum.GetValues<FlashcardType>().Select(b => new GetFlashcardTypeResponse(
                FlashcardTypeId: (int)b,
                FlashcardTypeName: b.ToString()
            )).ToList();

            return types;
        }
    }
}
