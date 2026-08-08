using MediatR;
using Microsoft.EntityFrameworkCore;
using SenseiApi.Persistence;

namespace SenseiApi.Features.Auth.Logout
{
    public class LogoutHandler
     : IRequestHandler<LogoutCommand>
    {
        private readonly AppDbContext _dbContext;

        public LogoutHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(
            LogoutCommand request,
            CancellationToken cancellationToken)
        {
            var refreshToken = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(
                    x => x.Token == request.RefreshToken,
                    cancellationToken);

            if (refreshToken is null)
                return;

            refreshToken.Revoke();

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
