using SenseiApi.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SenseiApi.Domain;
using SenseiApi.Persistence;

namespace SenseiApi.Features.Auth.Login;

public class LoginHandler
    : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly AppDbContext _dbContext;
    private readonly JwtGenerator _jwtGenerator;
    private readonly JwtOptions _jwtOptions;

    public LoginHandler(
        AppDbContext dbContext,
        JwtGenerator jwtTokenGenerator,
        IOptions<JwtOptions> jwtOptions)
    {
        _dbContext = dbContext;
        _jwtGenerator = jwtTokenGenerator;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(
                x => x.Email == request.Email,
                cancellationToken);

        if (user is null ||
            !BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash))
        {
            throw new UnauthorizedAccessException(
                "Invalid email or password.");
        }

        var accessToken =
            _jwtGenerator.GenerateAccessToken(user);

        var refreshToken =
            _jwtGenerator.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken(
            user.Id,
            refreshToken,
            DateTime.UtcNow.AddDays(
                _jwtOptions.RefreshTokenExpirationDays));

        _dbContext.RefreshTokens.Add(refreshTokenEntity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new LoginResponse(
            accessToken,
            refreshToken);
    }
}