using MediatR;

namespace SenseiApi.Features.Auth.Login
{
    public record LoginCommand(
        string Email,
        string Password
    ) : IRequest<LoginResponse>;
}
